// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestLogger.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The null logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SynesisIT.Infrastructure.Logger
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    /// <summary>
    ///     The null logger.
    /// </summary>
    public class TestLogger : ILogger
    {
        /// <summary>
        ///     The method trace start.
        /// </summary>
        public void MethodTraceStart()
        {
        }

        /// <summary>
        ///     The method trace end.
        /// </summary>
        public void MethodTraceEnd()
        {
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
            this.WriteDebug("NoNeed", string.Format("{0} Completed in {1} ms ({2} sec)", method, ts.TotalMilliseconds, ts.TotalSeconds, "End"));
        }

        /// <summary>
        /// The write info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteInfo(string message)
        {
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        public void WriteError(Exception ex)
        {
        }

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteError(string message)
        {
        }

        /// <summary>
        /// The write debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteDebug(string message)
        {
        }

        /// <summary>
        /// The write debug.
        /// </summary>
        /// <param name="NoNeed">
        /// The No Need.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void WriteDebug(string NoNeed, string message)
        {
            var stack = new StackTrace();
            var frame = stack.GetFrame(1);
            var method = frame.GetMethod();
            log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().Name).Info(message);
        }
    }
}
