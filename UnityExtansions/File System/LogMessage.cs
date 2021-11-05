using System;

namespace UnityEngine.IO
{
    internal struct LogMessage
    {
        public LogType LogType { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }

        public LogMessage(string message, LogType logType)
        {
            this.Message = message;
            this.LogType = logType;

            this.Time = DateTime.UtcNow;
        }
    }
}
