using Microsoft.Extensions.Logging;
using System;

namespace WkspWinForms.WinFormsApp.Logging
{
    public class ColorConsoleLoggerConfiguration
    {
        public int EventId { get; set; }
        public LogLevel LogLevel { get; set; } = LogLevel.Information;
        public ConsoleColor Color { get; set; } = ConsoleColor.Green;
    }
}
