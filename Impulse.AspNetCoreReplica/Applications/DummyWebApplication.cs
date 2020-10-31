namespace Impulse.Applications
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System;

    public interface IDummyWebApplication : IApplication
    {
    } // public interface IDummyWebApplication : IApplication

    public class DummyWebApplication : IDummyWebApplication
    {
        public void Run(string[] args)
        {
            Console.WriteLine("Hello from dummy web application");

            WebHost.CreateDefaultBuilder(args).UseStartup<DummyWebApplicationStartup>().Build().Run();
        }
    }
} // namespace Impulse.Applications