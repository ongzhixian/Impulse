using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Applications
{
    public class MicroWebApplication : IApplication
    {
        public void Run(string[] args)
        {
            Console.WriteLine("Hello from micro web application");

            WebHost.CreateDefaultBuilder(args).UseStartup<MicroWebApplicationStartup>().Build().Run();
        }
    }
}
