using System;
using System.Collections.Concurrent;
using System.Threading;

namespace UnityEngine.IO
{
    internal sealed class FileWriter : IDisposable
    {
        private string _folder;
        private string _filePath;
        private bool _disposing;

        private Thread _workingThread;
        private Thread _checNewDate;
        private DateTime _previosDate;

        private FileAppender _fileAppender;

        private readonly ConcurrentQueue<LogMessage> _messageQueue = new ConcurrentQueue<LogMessage>();
        private readonly ManualResetEvent _manualResetEvent = new ManualResetEvent(true);

        public FileWriter(string folder)
        {
            this._folder = folder;
            this.ManagePath();

            this._workingThread = ThreadUtilities.CreateBackgroundThread(this.StoreMessages);
            this._workingThread.Start();

            this._checNewDate = ThreadUtilities.CreateBackgroundThread(this.CheckNewDay);
            this._checNewDate.Start();
        }

        public void Write(LogMessage message)
        {
            try
            {
                if(message.Message.Length > LogUtilities.MaxLogMessageLength)
                {
                    string preview = message.Message.Substring(0, LogUtilities.MaxLogMessageLength);
                    this._messageQueue.Enqueue(new LogMessage($"Message is too long {message.Message.Length}. Preview: {preview}", message.LogType) 
                    {
                        Time = message.Time
                    });
                }
                else
                {
                    this._messageQueue.Enqueue(message);
                }
                this._manualResetEvent.Set();
            }
            catch
            {
                return;
            }
        }

        public void Dispose()
        {
            this._disposing = true;
            this._workingThread?.Abort();
            this._checNewDate?.Abort();
            GC.SuppressFinalize(this);
        }

        private void CheckNewDay()
        {
            while(this._disposing == false)
            {
                DateTime currentDate = DateTime.UtcNow;
                if(currentDate.Day != this._previosDate.Day)
                {
                    this._previosDate = currentDate;
                    this.ManagePath();
                }
                Thread.Sleep(1000);
            }
        }

        private void ManagePath()
        {
            this._previosDate = DateTime.UtcNow;
            this._filePath = $"{this._folder}/{DateTime.UtcNow.ToString(LogUtilities.LogDateFormat)}.log";
        }

        private void StoreMessages()
        {
            while(this._disposing == false)
            {
                while(this._messageQueue.IsEmpty == false)
                {
                    try
                    {
                        this.TryDequeueMessage();
                    }
                    catch
                    {
                        break;
                    }
                }

                this._manualResetEvent.Reset();
                this._manualResetEvent.WaitOne(500);
            }
        }

        private void TryDequeueMessage()
        {
            LogMessage message;
            if (this._messageQueue.TryPeek(out message) == false)
            {
                Thread.Sleep(5);
            }

            if (this._fileAppender == null || this._fileAppender.FileName != this._filePath)
            {
                this._fileAppender = new FileAppender(this._filePath);
            }

            string messageToWrite = String.Format(LogUtilities.LogMessageFormat, message.Time, message.LogType, message.Message);

            if (this._fileAppender.Append(messageToWrite))
            {
                this._messageQueue.TryDequeue(out message);
            }
            else
            {
                Thread.Sleep(5);
            }
        }
    }
}
