using Impulse.Logging.Loggers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Common.Extensions
{
    public static class ILoggingBuilderExtensions
    {
        ////////////////////////////////////////
        // ColorConsoleLogger

        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder) =>
            builder.AddColorConsoleLogger(new ColorConsoleLoggerConfiguration());

        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder, Action<ColorConsoleLoggerConfiguration> configure)
        {
            var config = new ColorConsoleLoggerConfiguration();
            configure(config);

            return builder.AddColorConsoleLogger(config);
        }

        public static ILoggingBuilder AddColorConsoleLogger(this ILoggingBuilder builder, ColorConsoleLoggerConfiguration config)
        {
            builder.AddProvider(new ColorConsoleLoggerProvider(config));
            return builder;
        }

        ////////////////////////////////////////
        // Log4Net

        public static ILoggingBuilder AddLog4NetLogger(this ILoggingBuilder builder, string log4netConfigFileName) =>
            builder.Log4NetLogger(new Log4NetConfiguration(log4netConfigFileName));

        //static ILoggingBuilder Log4NetLogger(this ILoggingBuilder builder, Action<Log4NetConfiguration> configure)
        //{
        //    var config = new Log4NetConfiguration();

        //    configure(config);

        //    return builder.Log4NetLogger(config);
        //}

        static ILoggingBuilder Log4NetLogger(this ILoggingBuilder builder, Log4NetConfiguration config)
        {
            builder.AddProvider(new Log4NetProvider(config));

            return builder;
        }
    }
}
