using log4net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Impulse.Logging.Loggers
{
    public class Log4NetConfiguration 
    {
        public string FileName { get; set; } = "log4net.config";

        //public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        //public LogLevel LogLevel { get; set; } = LogLevel.Information;

        //public Log4NetConfiguration()
        //{
        //}

        public Log4NetConfiguration(string fileName)
        {
            this.FileName = fileName;

            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(this.FileName));
        }

    }

    public class Log4NetLogger : ILogger
    {
        private readonly string name;
        //private readonly Log4NetConfiguration config;
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog log;

        public Log4NetLogger(string name)
        {
            this.name = name;

            this.log = LogManager.GetLogger(this.name);
        }
            
        public IDisposable BeginScope<TState>(TState state) => default;

        //public bool IsEnabled(LogLevel logLevel) => logLevel == this.config.LogLevel;
        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            switch (logLevel)
            {
                case LogLevel.Trace:
                case LogLevel.Debug:
                case LogLevel.Information:
                case LogLevel.Warning:
                case LogLevel.Error:
                case LogLevel.Critical:
                    log.Info($"[{eventId.Id,2}: {logLevel,-12}]  {this.name} - {formatter(state, exception)}");
                    break;
                default:
                    log.Info($"[{eventId.Id,2}: {logLevel,-12}]  {this.name} - {formatter(state, exception)}");
                    break;
            }

            //if (_config.EventId == 0 || _config.EventId == eventId.Id)
            //{
            //    ConsoleColor originalColor = Console.ForegroundColor;

            //    Console.ForegroundColor = _config.Color;
            //    Console.WriteLine($"[{eventId.Id,2}: {logLevel,-12}]");

            //    Console.ForegroundColor = originalColor;
            //    Console.WriteLine($"     {_name} - {formatter(state, exception)}");
            //}
        }
    }

    public class Log4NetProvider : ILoggerProvider
    {
        private readonly Log4NetConfiguration _config;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers = new ConcurrentDictionary<string, Log4NetLogger>();

        public Log4NetProvider(Log4NetConfiguration config) =>
            _config = config;

        public ILogger CreateLogger(string categoryName) => 
            _loggers.GetOrAdd(categoryName, name => new Log4NetLogger(name));

        public void Dispose() => _loggers.Clear();
    }

    public class Log4NetConfigurationProvider : ConfigurationProvider
    {
        string log4netConfigFileName;

        public Log4NetConfigurationProvider(string log4netConfigFileName)
        {
            this.log4netConfigFileName = log4netConfigFileName;
        }

        public override void Load()
        {
            Data.Add("Log4NetConfig", this.log4netConfigFileName);
        }
    }


    public class Log4NetConfigurationSource : IConfigurationSource
    {
        string log4netConfigFileName;

        public Log4NetConfigurationSource(string log4netConfigFileName)
        {
            this.log4netConfigFileName = log4netConfigFileName;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new Log4NetConfigurationProvider(this.log4netConfigFileName);
        }
    }

}


namespace Impulse.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddLog4NetProvider(this IConfigurationBuilder configuration, string log4netConfigFileName)
        {
            configuration.Add(new Logging.Loggers.Log4NetConfigurationSource(log4netConfigFileName));
            return configuration;
        }
    }

    public static class LoggingBuilderContextExtensions
    {
        public static ILoggingBuilder AddLog4NetProvider(this ILoggingBuilder logging, string log4netConfigFileName)
        {
            logging.AddProvider(new Logging.Loggers.Log4NetProvider(new Logging.Loggers.Log4NetConfiguration(log4netConfigFileName)));
            return logging;
        }
    }

}

