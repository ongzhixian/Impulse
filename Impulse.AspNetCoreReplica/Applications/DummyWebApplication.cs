namespace Impulse.Applications
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using System;
    using System.Threading.Tasks;
    using Impulse.Common;

    public interface IDummyWebApplication : IApplication
    {
    } // public interface IDummyWebApplication : IApplication

    public class DummyWebApplication : IDummyWebApplication
    {
        public Task RunAsync(string[] args)
        {
            Console.WriteLine("Hello from dummy web application");

            return WebHost.CreateDefaultBuilder(args).UseStartup<DummyWebApplicationStartup>().Build().RunAsync();
        }

    }
} // namespace Impulse.Applications