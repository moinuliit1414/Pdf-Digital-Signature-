// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectPool.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The Object Pool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SynesisIT.Infrastructure.Logger;

namespace SynesisIT.PDFSign.Helper
{
    public class ObjectPool<T> where T : class
    {
        private readonly int _size;
        private SpinLock _spinLock;
        private ILogger _logger;

        private T _firstItem;
        private readonly Stack<T> _cache;

        public ObjectPool() : this(Environment.ProcessorCount * 2) { }

        public ObjectPool(int size)
        {
            _logger = new Logger();
            _size = size;
            _cache = new Stack<T>();
            _spinLock = new SpinLock(false);
        }

        /// <summary>
        /// Produces an instance.
        /// </summary>
        public T Rent()
        {
            bool lockTaken = false;
            _spinLock.Enter(ref lockTaken);

            try
            {
                T instance = _firstItem;
                if (instance == null || instance != Interlocked.CompareExchange(ref _firstItem, null, instance))
                {
                    instance = RentFromCache();
                }

                return instance;
            }
            finally
            {
                if (lockTaken)
                {
                    _spinLock.Exit(false);
                }
            }
        }
        //public bool IsEmptyPool(){

        //    return _firstItem == null;
        //}

        /// <summary>
        /// Produces an instance by deep clone.
        /// </summary>
        /// <param name="obj">
        /// The generic instance.
        /// </param>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        private T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

        /// <summary>
        /// Produces an instance by Shallow Clone.
        /// </summary>
        /// <param name="instance">
        /// The generic object.
        /// </param>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        private T ShallowClone<T>(T instance)
        {
            Type type = instance.GetType();

            if (instance is ICloneable)
            {
                return (T)((ICloneable)instance).Clone();
            }
            else {
                return DeepClone<T>(instance);
            }
        }

        /// <summary>
        /// Rent instance From Cache if exist.
        /// </summary>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        private T RentFromCache()
        {
            if (_cache.Count > 0)
            {
                T instance = _cache.Pop();

                if (instance != null)
                {
                    return instance;
                }
            }
            _logger.WriteDebug("Create new Instance");
            return CreateInstance();
        }

        /// <summary>
        /// Create Instance if cash Instance is not exist.
        /// </summary>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        private T CreateInstance()
        {
            if (_firstItem==null)
            {
                T obj = default(T);
                obj =Activator.CreateInstance<T>();
                //_firstItem=obj;
                return obj;
            }else{

                return ShallowClone(_firstItem);
            }
        }

        /// <summary>
        /// Returns objects to the pool.
        /// </summary>
        public void Return(T obj)
        {
            _logger.WriteDebug("Start");
            bool lockTaken = false;
            _spinLock.Enter(ref lockTaken);

            try
            {
                if (_firstItem == null)
                {
                    _firstItem = obj;
                }
                else
                {
                    ReturnToCache(obj);
                }
            }
            finally
            {
                if (lockTaken)
                {
                    _spinLock.Exit(false);
                }
            }
            _logger.WriteDebug("End");
        }

        /// <summary>
        /// Returns objects to the Cache.
        /// </summary>
        private void ReturnToCache(T obj)
        {
            _logger.WriteDebug("Start");
            if (_cache.Count >= _size)
            {
                _logger.WriteDebug("Return To Cache:" + _cache.Count.ToString());
                return;
            }
            _cache.Push(obj);
            _logger.WriteDebug("End");
        }
    }
}