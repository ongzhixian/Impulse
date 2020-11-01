using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Logging.Loggers
{
    public class SimpleConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            // this logger does not support scopes
            // See below link for how scopes are suppose to work:
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#log-scopes-1
            return null; 
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            // We support all log levels
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = string.Empty;

            if (formatter != null)
            {
                message = formatter(state, exception);
            }
            else
            {
                // default
                // message = LogFormatter.Formatter(state, exception);
            }

            //LogDataQueue.Enqueue(message);
        }
    }
}
