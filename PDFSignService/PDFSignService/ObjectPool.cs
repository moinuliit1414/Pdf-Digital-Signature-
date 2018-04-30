using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace PDFSignService
{
    public class ObjectPool<T> where T : class
    {
        private readonly int _size;
        private readonly Func<T> _factory;
        private SpinLock _spinLock;

        // storage for the pool objects.
        // the first item is expected to be most often case.
        private T _firstItem;
        private readonly Stack<T> _cache; //Use Queue<T> for first-in-first-out (FIFO)

        public ObjectPool(Func<T> factory) : this(factory, Environment.ProcessorCount * 2) { }

        public ObjectPool(Func<T> factory, int size)
        {
            _factory = factory;
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

        private T RentFromCache()
        {
            //var cache = _cache;

            if (_cache.Count > 0)
            {
                T instance = _cache.Pop();

                if (instance != null)
                {
                    return instance;
                }
            }

            return CreateInstance();
        }

        private T CreateInstance()
        {
            var instance = _factory();
            return instance;
        }

        /// <summary>
        /// Returns objects to the pool.
        /// </summary>
        public void Return(T obj)
        {
            bool lockTaken = false;
            _spinLock.Enter(ref lockTaken);

            try
            {
                if (_firstItem == null)
                {
                    // worst case scenario: two objects may be stored into same slot.
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
        }

        private void ReturnToCache(T obj)
        {
            //var cache = _cache;

            if (_cache.Count >= _size)
            {
                // not a big fan of doing it this way
                return;
            }

            // worst case scenario: two objects may be stored into same slot.
            _cache.Push(obj);
        }
    }
}