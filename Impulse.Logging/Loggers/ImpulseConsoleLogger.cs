namespace Impulse.Logging.Loggers
{
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;
    using System;
    using System.IO;
    using System.Runtime.Serialization;

    /// <summary>
    /// This implementation is not used.
    /// To see how the .NET Runtime does this, see:
    /// https://github.com/dotnet/runtime/tree/master/src/libraries/Microsoft.Extensions.Logging.Console/src
    /// Or maybe better:
    /// https://github.com/dotnet/extensions/tree/aabe8c34a62786c313e20125d70b36d3c5e72a75/src/Logging/Logging.Console/src
    /// </summary>
    public class ImpulseConsoleLogger : ILogger
    {
        private readonly string _name;
        private readonly ImpulseConsoleLoggerProcessor _queueProcessor;

        [ThreadStatic]
        private static StringWriter t_stringWriter;

        public ImpulseConsoleLogger(string name, ImpulseConsoleLoggerProcessor loggerProcessor)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            _name = name;
            _queueProcessor = loggerProcessor;

            
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            //return ScopeProvider?.Push(state) ?? NullScope.Instance;
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            if (t_stringWriter == null)
                t_stringWriter = new StringWriter();

            //LogEntry<TState> logEntry = new LogEntry<TState>(logLevel, _name, eventId, state, exception, formatter);
            //Formatter.Write(in logEntry, ScopeProvider, t_stringWriter);
            

            var sb = t_stringWriter.GetStringBuilder();

            if (sb.Length == 0)
            {
                return;
            }

            string computedAnsiString = sb.ToString();
            sb.Clear();

            if (sb.Capacity > 1024)
            {
                sb.Capacity = 1024;
            }

            //_queueProcessor.EnqueueMessage(new LogMessage(computedAnsiString, logAsError: logLevel >= Options.LogToStandardErrorThreshold));
        }
    }
}
