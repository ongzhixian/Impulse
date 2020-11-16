namespace Impulse.Applications
{
    using Impulse.Web.AspNetCoreReplica;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.IO;
    using System.Reflection;
    using NLog.Web;
    using Serilog;

    public class MicroWebApplication : IApplication
    {
        public System.Threading.Tasks.Task RunAsync(string[] args)
        {
            Console.WriteLine("Hello from micro web application");

            // TODO: Find the breakdown of CreateDefaultBuilder (what it does)

            var builder = ReplicaWebHost
                .CreateDefaultBuilder(args)
                .UseNLog()

                // ZX: Warning! Serilog is opinionated and does not play nice with the default ILoggerFactory!
                // UseSerilog() extension calls ConfigureServices() on IHostBuilder and replaces ILoggerFactory with SerilogLoggerFactory. 
                // Hence, when services requires ILoggerFactory (eg. to create an ILogger), we get SerilogLoggerFactory instead.
                // This is not so good.
                // LoggerFactory allows multiple providers to be active at once (e.g. a Console provider, a Debug provider, a File provider etc). 
                // In contrast, SerilogLoggerFactory allows only the Serilog provider, and ignores all others.
                // There is a way to make Serilog write to other providers as well (see example below)
                // See section "How the library works behind the scenes" in the below url:
                // https://andrewlock.net/adding-serilog-to-the-asp-net-core-generic-host/

                //.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
                //{
                //    loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                //})

                // Example setting preserveStaticLogger and writeToProviders
                //.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
                //{
                //    loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
                //}, true, true)
                ;


            var runner = builder.UseStartup<MicroWebApplicationStartup>().Build();

            return runner.RunAsync();

        } // public void Run(string[] args)
    } // public class MicroWebApplication : IApplication

    
} // namespace Impulse.Applications
