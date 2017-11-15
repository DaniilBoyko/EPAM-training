using System;

namespace Watch
{
    /// <summary>
    /// Argument for send to listeners of Watch.
    /// </summary>
    public class TimeLeftEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor initialize the instance of the <see cref="TimeLeftEventArgs"/> class.
        /// </summary>
        /// <param name="message">message</param>
        public TimeLeftEventArgs(string message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Message to send.
        /// </summary>
        public string Message { get; set; }
    }
}
