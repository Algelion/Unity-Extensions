using System;
using System.IO;
using System.Text;

namespace UnityEngine.IO
{
    internal sealed class FileAppender
    {
        private readonly object _lockObject = new object();

        public string FileName { get; set; }

        public FileAppender(string fileName)
        {
            this.FileName = fileName;
        }

        public bool Append(string content)
        {
            try
            {
                lock (this._lockObject)
                {
                    using (FileStream fileStream = File.Open(this.FileName, FileMode.Append, FileAccess.Write, FileShare.Read))
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(content);
                        fileStream.Write(bytes, 0, bytes.Length);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            return false;
        }
    }
}
