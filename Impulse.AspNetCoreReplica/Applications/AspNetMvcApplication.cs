namespace Impulse.Applications
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using NLog.Web;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Impulse.Common;

    public class AspNetMvcApplication : IApplication
    {
        public Task Run(string[] args)
        {
            Console.WriteLine("Hello from ASP.NET Core MVC web application");

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("hostsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            IWebHostBuilder builder = WebHost
                .CreateDefaultBuilder(args)
                .UseConfiguration(config)
                .UseNLog()
                //.Configure(app =>
                //{
                //    app.Run(context =>
                //        context.Response.WriteAsync("Hello, World!"));
                //});
                ;

            IWebHost runner = builder.UseStartup<AspNetMvcApplicationStartup>().Build();

            return runner.RunAsync();
            
        } // public void Run(string[] args)
    } // public class AspNetMvcApplication : IApplication
} // namespace Impulse.Applications
