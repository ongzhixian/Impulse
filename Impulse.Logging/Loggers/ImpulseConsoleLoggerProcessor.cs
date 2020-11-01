namespace Impulse.Logging.Loggers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;


    public struct LogMessage
    {
        public LogMessage(string message, bool logAsError = false)
        {
            Message = message;
            LogAsError = logAsError;
        }

        public readonly string Message;
        public readonly bool LogAsError;
    }

    public class ImpulseConsoleLoggerProcessor : IDisposable
    {
        private const int _maxQueuedMessages = 1024;

        private readonly BlockingCollection<LogMessage> _messageQueue = new BlockingCollection<LogMessage>(_maxQueuedMessages);
        private readonly Thread _outputThread;

        public IConsole Console;
        public IConsole ErrorConsole;

        public ImpulseConsoleLoggerProcessor()
        {
            // Start Console message queue processor
            _outputThread = new Thread(ProcessLogQueue)
            {
                IsBackground = true,
                Name = "Console logger queue processing thread"
            };
            _outputThread.Start();
        }

        public virtual void EnqueueMessage(LogMessage message)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(message);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            // Adding is completed so just log the message
            try
            {
                WriteMessage(message);
            }
            catch (Exception) { }
        }

        // for testing
        internal virtual void WriteMessage(LogMessage entry)
        {
            IConsole console = entry.LogAsError ? ErrorConsole : Console;
            console.Write(entry.Message);
        }

        private void ProcessLogQueue()
        {
            try
            {
                foreach (LogMessage message in _messageQueue.GetConsumingEnumerable())
                {
                    WriteMessage(message);
                }
            }
            catch
            {
                try
                {
                    _messageQueue.CompleteAdding();
                }
                catch { }
            }
        }

        public void Dispose()
        {
            _messageQueue.CompleteAdding();

            try
            {
                _outputThread.Join(1500); // with timeout in-case Console is locked by user input
            }
            catch (ThreadStateException) { }
        }

    }
}
