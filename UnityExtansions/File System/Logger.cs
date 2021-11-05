namespace UnityEngine.IO
{
    public sealed class Logger : MonoBehaviour
    {
        private FileWriter _fileWriter;

        private void Awake()
        {
            this._fileWriter = new FileWriter(LogUtilities.LogDirectory);
            Application.logMessageReceivedThreaded += this.OnLogMessageReceived;
        }

        private void OnLogMessageReceived(string condition, string stackTrace, LogType type)
        {
            if(type == LogType.Exception)
            {
                this._fileWriter.Write(new LogMessage(condition, type));
                this._fileWriter.Write(new LogMessage(stackTrace, type));
            }
            else
            {
                this._fileWriter.Write(new LogMessage(condition, type));
            }
        }

        private void OnDestroy()
        {
            this._fileWriter.Dispose();
        }
    }
}
