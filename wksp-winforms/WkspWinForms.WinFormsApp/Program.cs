using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;
using WkspWinForms.WinFormsApp.Logging;

namespace WkspWinForms.WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                ServiceProvider serviceProvider = GetServiceProvider();
                ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                ILogger log = loggerFactory.CreateLogger("Main");

                log.LogInformation("[START PROGRAM]");
                
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(serviceProvider.GetRequiredService<MdiMainForm>());

                log.LogInformation("[END PROGRAM]");
            }
            catch (Exception)
            {
                throw;
            }
        }

        static IServiceCollection ConfigureServices()
        {
            try
            {
                IServiceCollection serviceCollection = new ServiceCollection();

                serviceCollection.AddLogging(builder => builder
                    .AddConsole()
                    .AddFilter(level => level >= LogLevel.Information)
                    .AddLog4NetLogger()
                    //.AddProvider(new ColorConsoleLoggerProvider(
                    //    new ColorConsoleLoggerConfiguration
                    //    {
                    //        LogLevel = LogLevel.Error,
                    //        Color = ConsoleColor.Red
                    //    }))
                    //    .AddColorConsoleLogger()
                    //    .AddColorConsoleLogger(configuration =>
                    //    {
                    //        configuration.LogLevel = LogLevel.Warning;
                    //        configuration.Color = ConsoleColor.DarkMagenta;
                    //    })
                );

                serviceCollection.AddTransient<MdiMainForm>();
                serviceCollection.AddTransient<Form2>();

                return serviceCollection;
            }
            catch (Exception)
            {

                throw;
            }
        }

        static ServiceProvider GetServiceProvider()
        {
            try
            {
                return ConfigureServices().BuildServiceProvider();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
