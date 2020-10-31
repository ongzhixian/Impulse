namespace Impulse.Applications
{
    using Impulse.Web.AspNetCoreReplica;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MicroWebApplicationStartup
    {
        ILogger<MicroWebApplicationStartup> logger;

        public MicroWebApplicationStartup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            logger = loggerFactory.CreateLogger<MicroWebApplicationStartup>();
            logger.LogInformation("Created logger for MicroWebApplicationStartup");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.LogInformation("Configure services for MicroWebApplicationStartup");

            var serviceList = services.OrderBy(_ => _.Lifetime).ToList();
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("services.txt"))
            {
                sw.AutoFlush = true;

                foreach (var item in serviceList)
                {
                    sw.WriteLine("{0} {1} {2} {3} {4}",
                        item.Lifetime,
                        item.ServiceType,
                        item.ImplementationFactory,
                        item.ImplementationType,
                        item.ImplementationInstance
                        );
                }
            }

            //services.AddHttpContextAccessor

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //var logger = services.BuildServiceProvider().GetRequiredService<ILogger>();
            //logger.LogInformation("Finish configuring services.");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            //app.Use(async (context, next) =>
            //{
            //    // Do work that doesn't write to the Response.
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            app.Use(async (context, next) =>
            {
                var cultureQuery = context.Request.Query["culture"];
                if (!string.IsNullOrWhiteSpace(cultureQuery))
                {
                    var culture = new System.Globalization.CultureInfo(cultureQuery);

                    System.Globalization.CultureInfo.CurrentCulture = culture;
                    System.Globalization.CultureInfo.CurrentUICulture = culture;
                }

                // Call the next delegate/middleware in the pipeline
                await next();
            });


            //IDictionary<string, Action<ReplicaEndpointConfiguration>> EndpointConfigurations
            //    = new Dictionary<string, Action<ReplicaEndpointConfiguration>>(0, StringComparer.OrdinalIgnoreCase);
            //EndpointConfigurations.TryGetValue("AA")


        //System.Net.HttpListenerContext ct;
        //ct.Request.InputStream


            // RequestDelegate
            app.Run(async _ =>
            {
                //var msg = Configuration["message"];

                string body = string.Empty;

                //using (var reader = new System.IO.StreamReader(_.Request.Body))
                //{
                //    body = reader.ReadToEnd();
                //}

                // ZX: Whoever replied using the following code can get the raw HTTP request is an idiot!
                //     This only give you the body the request :-(
                //using (System.IO.MemoryStream memstream = new System.IO.MemoryStream())
                //using (System.IO.StreamReader reader = new System.IO.StreamReader(memstream))
                //{
                //    _.Request.Body.CopyTo(memstream);
                //    memstream.Position = 0;
                //    body = reader.ReadToEnd();
                //}

                //System.Net.Http.HttpMessageHandler;

                await _.Response.WriteAsync(body);

                //await _.Response.WriteAsync("hello world from micro web app");
            });

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseCookiePolicy();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

        }
    } // public class MicroWebApplicationStartup
} // namespace Impulse.Applications
