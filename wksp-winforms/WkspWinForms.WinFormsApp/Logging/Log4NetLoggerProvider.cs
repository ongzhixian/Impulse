using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace WkspWinForms.WinFormsApp.Logging
{
    public class Log4NetLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, Log4NetLogger> loggers =
            new ConcurrentDictionary<string, Log4NetLogger>();

        public ILogger CreateLogger(string categoryName)
        {
            return new Log4NetLogger(categoryName);
        }

        public void Dispose() => loggers.Clear();
    }
}
