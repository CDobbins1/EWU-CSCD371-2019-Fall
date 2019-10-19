using System;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        private readonly string _FilePath;
        public FileLogger(string filePath) => this._FilePath = filePath;
        public override void Log(LogLevel logLevel, string message)
        {
            string logMessage = $"{DateTime.Now} {ClassName} {logLevel}: {message}{Environment.NewLine}";

            System.IO.File.AppendAllText(_FilePath, logMessage);
        }
    }
}
