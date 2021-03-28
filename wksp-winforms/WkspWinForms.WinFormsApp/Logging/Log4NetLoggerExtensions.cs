using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WkspWinForms.WinFormsApp.Logging
{
    public static class Log4NetLoggerExtensions
    {
        public static ILoggingBuilder AddLog4NetLogger(this ILoggingBuilder builder)
        {
            return builder.AddProvider(new Log4NetLoggerProvider());
        }
    }
}
