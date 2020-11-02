using Microsoft.AspNetCore.HostFiltering;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Reflection;

namespace Impulse.Web.AspNetCoreReplica
{

    /// <summary>
    /// This is not full implementation but an adaptation to investigate inner workings
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/DefaultBuilder/src/WebHost.cs
    /// </summary>
    public static class ReplicaWebHost
    {
        public static IWebHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new WebHostBuilder();

            if (string.IsNullOrEmpty(builder.GetSetting(WebHostDefaults.ContentRootKey)))
            {
                builder.UseContentRoot(Directory.GetCurrentDirectory());
            }

            if (args != null)
            {
                builder.UseConfiguration(new ConfigurationBuilder().AddCommandLine(args).Build());
            }

            builder
                .UseKestrel((builderContext, options) =>
                {
                    // Notes on order of execution of ReplicaUseKestrel
                    // 1) IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder, Action<WebHostBuilderContext, KestrelServerOptions> configureOptions)
                    // 2) IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder)



                    //IDictionary<string, Action<ReplicaEndpointConfiguration>> EndpointConfigurations
                    //    = new Dictionary<string, Action<ReplicaEndpointConfiguration>>(0, StringComparer.OrdinalIgnoreCase);

                    // options is KestrelServerOptions
                    //ReplicaAdhoc.Configure(options, builderContext.Configuration.GetSection("Kestrel"));


                    Microsoft.AspNetCore.Server.Kestrel.KestrelConfigurationLoader kestrelConfigurationLoader =
                        options.Configure(builderContext.Configuration.GetSection("Kestrel"));
                    //kestrelConfigurationLoader.Endpoint("Http", configureOptions =>
                    //{
                    //    configureOptions.ListenOptions.UseConnectionLogging();
                    //    //
                    //    configureOptions.ListenOptions.ConnectionAdapters.Add(new ReplicaLoggingConnectionAdapter(logger))
                    //});


                    //options.Listen(new System.Net.IPEndPoint(System.Net.IPAddress.Any, 38493), listenOptions =>
                    //{
                    //    var loggerFactory = listenOptions.KestrelServerOptions.ApplicationServices.GetRequiredService<ILoggerFactory>();
                    //    var logger = loggerName == null ? loggerFactory.CreateLogger<ReplicaLoggingConnectionAdapter>() : loggerFactory.CreateLogger(loggerName);
                    //    listenOptions.ConnectionAdapters.Add(new ReplicaLoggingConnectionAdapter(logger));
                    //});


                    options.Configure(builderContext.Configuration.GetSection("Kestrel")).Endpoint("Http", configureOptions =>
                    {
                        configureOptions.ListenOptions.UseConnectionLogging();
                        //
                        //configureOptions.ListenOptions.ConnectionAdapters.Add(new ReplicaLoggingConnectionAdapter(logger))
                    });




                    // Break to debug
                    // System.Diagnostics.Debugger.Break();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                          .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }

                    config.AddEnvironmentVariables();

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                //.ConfigureLogging((hostingContext, logging) =>
                //{
                //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //    logging.AddConsole();
                //    logging.AddDebug();
                //    logging.AddEventSourceLogger();
                //})
                .ConfigureServices((hostingContext, services) =>
                {
                    // Fallback
                    services.PostConfigure<HostFilteringOptions>(options =>
                    {
                        if (options.AllowedHosts == null || options.AllowedHosts.Count == 0)
                        {
                            // "AllowedHosts": "localhost;127.0.0.1;[::1]"
                            var hosts = hostingContext.Configuration["AllowedHosts"]?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            // Fall back to "*" to disable.
                            options.AllowedHosts = (hosts?.Length > 0 ? hosts : new[] { "*" });
                        }
                    });
                    // Change notification
                    services.AddSingleton<IOptionsChangeTokenSource<HostFilteringOptions>>(
                        new ConfigurationChangeTokenSource<HostFilteringOptions>(hostingContext.Configuration));

                    services.AddTransient<IStartupFilter, ReplicaHostFilteringStartupFilter>();
                })
                .UseIIS()
                .UseIISIntegration()
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                });

            return builder;
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            IHostBuilder builder = null;// = new HostBuilder();

            //builder.ConfigureHostConfiguration((configurationBuilder) => { });
            //builder.ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) => { });
            //builder.ConfigureServices((hostBuilderContext, serviceCollection) => { });
            
            //
            //builder.ConfigureContainer((hostBuilderContext, containerBuilder) => { });

            return builder;
        }

        // Another way to write the above:
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //        new HostBuilder()
        //.ConfigureHostConfiguration(builder => { /* Host configuration */ })
        //.ConfigureAppConfiguration(builder => { /* App configuration */ })
        //.ConfigureServices(services => { /* Service configuration */})
        //.UseSerilog(); // <- Add this line

    }
}
