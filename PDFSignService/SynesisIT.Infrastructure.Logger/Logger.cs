// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Logger.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2016
// </copyright>
// <summary>
//   The logging.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SynesisIT.Infrastructure.Logger
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using log4net;

    /// <summary>
    ///     The logging.
    /// </summary>
    public class Logger : ILogger
    {
        /// <summary>
        ///     The method trace start.
        /// </summary>
        public void MethodTraceStart()
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteDebug(method, "Start");
        }

        /// <summary>
        ///     The method trace end.
        /// </summary>
        public void MethodTraceEnd()
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteDebug(method, "End");
        }

        /// <summary>
        ///     The method trace start time.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateTime" />.
        /// </returns>
        public DateTime MethodTraceStartTime()
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteDebug(method, "Start");
            return DateTime.UtcNow;
        }

        /// <summary>
        /// The method trace end.
        /// </summary>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        public void MethodTraceEnd(DateTime startTime)
        {
            var ts = DateTime.UtcNow - startTime;
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteDebug(string.Format("{0} Completed in {1} ms ({2} sec)", method, ts.TotalMilliseconds, ts.TotalSeconds));
        }

        /// <summary>
        /// The write debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteDebug(string message)
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteDebug(method, message);
        }

        /// <summary>
        /// The write info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteInfo(string message)
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteInfo(method, message);
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public void WriteError(Exception ex)
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteError(method, ex);
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteError(string message)
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            this.WriteError(method, message);
        }

        /// <summary>
        /// The write info.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private void WriteInfo(MethodBase method, string message)
        {
            log4net.LogManager.GetLogger("FileAppender").Info(this.GetMethodSignature(method) + " " + message);
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="ex">
        /// The ex.
        /// </param>
        private void WriteError(MethodBase method, Exception ex)
        {
            log4net.LogManager.GetLogger("FileAppender").Error(this.GetMethodSignature(method), ex);
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private void WriteError(MethodBase method, string message)
        {
            log4net.LogManager.GetLogger("FileAppender").Error(this.GetMethodSignature(method) + " " + message);
        }

        /// <summary>
        /// The write debug.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        private void WriteDebug(MethodBase method, string message)
        {
            log4net.LogManager.GetLogger("FileAppender").Debug(this.GetMethodSignature(method) + " " + message);
        }

        /// <summary>
        /// The get method signature.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetMethodSignature(MethodBase method)
        {
            var parameterText = string.Empty;
            var parameterInfos = method.GetParameters().GetEnumerator();
            while (parameterInfos.MoveNext())
            {
                var parameterInfo = parameterInfos.Current as ParameterInfo;
                if (parameterInfo != null)
                {
                    parameterText += (parameterText != string.Empty ? "," : string.Empty) + parameterInfo.Name;
                }
            }

            var methodSignature = method.Name + "(" + parameterText + ")";

            if (method.ReflectedType == null)
            {
                return methodSignature;
            }

            return method.ReflectedType.FullName + "." + methodSignature;
        }
    }
}
