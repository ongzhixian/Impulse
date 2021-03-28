using log4net;
using Microsoft.Extensions.Logging;
using System;

namespace WkspWinForms.WinFormsApp.Logging
{
    public class Log4NetLogger : ILogger
    {
        private readonly ILog log;
        public Log4NetLogger(string categoryName)
        {
            log = LogManager.GetLogger(categoryName);
            // log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public IDisposable BeginScope<TState>(TState state) => default;

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:        // 0
                    return true;
                case LogLevel.Debug:        // 1
                    return log.IsDebugEnabled;
                case LogLevel.Information:  // 2
                    return log.IsInfoEnabled;
                case LogLevel.Warning:      // 3
                    return log.IsWarnEnabled;
                case LogLevel.Error:        // 4
                    return log.IsErrorEnabled;
                case LogLevel.Critical:     // 5
                    return log.IsFatalEnabled;
                case LogLevel.None:         // 6
                    return false;
                default:
                    return false;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            // LogLevel                   //    Log4Net LogLevel
            //case LogLevel.Trace:        // 0  All(log everything)
            //case LogLevel.Debug:        // 1  log.Debug
            //case LogLevel.Information:  // 2  log.Info
            //case LogLevel.Warning:      // 3  log.Warn
            //case LogLevel.Error:        // 4  log.Error
            //case LogLevel.Critical:     // 5  log.Fatal
            //case LogLevel.None:         // 6  Off(don’t log anything)

            switch (logLevel)
            {
                case LogLevel.Trace:        // 0
                case LogLevel.Debug:        // 1
                    log.Debug(formatter(state, exception), exception);
                    break;
                case LogLevel.Information:  // 2
                    log.Info(formatter(state, exception), exception);
                    break;
                case LogLevel.Warning:      // 3
                    log.Warn(formatter(state, exception), exception);
                    break;
                case LogLevel.Error:        // 4
                    log.Error(formatter(state, exception), exception);
                    break;
                case LogLevel.Critical:     // 5
                    log.Fatal(formatter(state, exception), exception);
                    break;
                case LogLevel.None:         // 6
                default:
                    break;
            }
        }
    }
}
