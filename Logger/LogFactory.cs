namespace Logger
{
    public class LogFactory
    {
        private string _FilePath;
        public BaseLogger CreateLogger(string className)
        {
            if (_FilePath is null) return null;

            var logger = new FileLogger(_FilePath) { ClassName = className ?? "CLASSNAME NOT GIVEN" };
            return logger;
        }

        public void ConfigureFileLogger(string filePath) => this._FilePath = filePath;
    }
}
