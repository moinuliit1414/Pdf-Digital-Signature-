// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogger.cs" email="Moinul Islam<moinul39.iit@gmail.com>">
//   Copyright @ 2018
// </copyright>
// <summary>
//   The Logger interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SynesisIT.Infrastructure.Logger
{
    using System;

    /// <summary>
    ///     The Logger interface.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        ///     The method trace start.
        /// </summary>
        void MethodTraceStart();

        /// <summary>
        ///     The method trace end.
        /// </summary>
        void MethodTraceEnd();

        /// <summary>
        ///     The method trace start time.
        /// </summary>
        /// <returns>
        ///     The <see cref="DateTime" />.
        /// </returns>
        DateTime MethodTraceStartTime();

        /// <summary>
        /// The method trace end.
        /// </summary>
        /// <param name="startTime">
        /// The start time.
        /// </param>
        void MethodTraceEnd(DateTime startTime);

        /// <summary>
        /// The write debug.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void WriteDebug(string message);

        /// <summary>
        /// The write info.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void WriteInfo(string message);

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="ex">
        /// The ex.
        /// </param>
        void WriteError(Exception ex);

        /// <summary>
        /// The write error.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void WriteError(string message);
    }
}
