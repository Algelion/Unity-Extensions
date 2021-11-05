using System.IO;

namespace UnityEngine
{
    public static class LogUtilities
    {
        public static string LogDirectory { get; set; }

        public static readonly string LogMessageFormat;
        public static readonly string LogDateFormat;
        public static readonly int MaxLogMessageLength;

        static LogUtilities()
        {
            LogUtilities.LogDirectory = $"{Application.persistentDataPath}/Logs";

            if(Directory.Exists(LogUtilities.LogDirectory) == false)
            {
                Directory.CreateDirectory(LogUtilities.LogDirectory);
            }

            LogUtilities.LogMessageFormat = "{0:dd/MM/yyyy HH:mm:ss:FFFF} [{1}]: {2}\r";
            LogUtilities.LogDateFormat = "yyyy-MM-dd";
            LogUtilities.MaxLogMessageLength = 1000;
        }
    }
}
