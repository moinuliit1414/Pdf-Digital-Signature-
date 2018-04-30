// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullLogger.cs" company="SynesisIT Ltd.">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The null logger.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SynesisIT.Infrastructure.Logger
{
    using System;

    /// <summary>
    ///     The null logger.
    /// </summary>
    public class NullLogger : ILogger
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
            return DateTime.Now;
        }

        /// <summary>
        /// The method trace end.
        /// </summary>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        public void MethodTraceEnd(DateTime startTime)
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
    }
}
