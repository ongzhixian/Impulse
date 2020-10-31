namespace Impulse.Applications
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Impulse.Common.Extensions;

    public class AspNetMvcApplicationStartup
    {
        ILogger<AspNetMvcApplicationStartup> logger;

        public AspNetMvcApplicationStartup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            logger = loggerFactory.CreateLogger<AspNetMvcApplicationStartup>();
            logger.LogInformation("Created logger for AspNetMvcApplicationStartup");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            logger.LogInformation("Configure services for AspNetMvcApplicationStartup");

            logger.Info(services);
            
            

            //var serviceList = services.OrderBy(_ => _.Lifetime).ToList();
            //using (System.IO.StreamWriter sw = new System.IO.StreamWriter("services.txt"))
            //{
            //    sw.AutoFlush = true;

            //    foreach (var item in serviceList)
            //    {
            //        sw.WriteLine("{0} {1} {2} {3} {4}",
            //            item.Lifetime,
            //            item.ServiceType,
            //            item.ImplementationFactory,
            //            item.ImplementationType,
            //            item.ImplementationInstance
            //            );
            //    }
            //}


            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});



            //var logger = services.BuildServiceProvider().GetRequiredService<ILogger>();
            logger.LogInformation("Finish configuring services.");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var p = services.BuildServiceProvider();

            var pm = p.GetRequiredService<Microsoft.AspNetCore.Mvc.ApplicationParts.ApplicationPartManager>();

            //var r = p.GetRequiredService<Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorReferenceManager>();

            //ApplicationPartManager _partManager = builder.PartManager;
            //Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature feature = 
            //    new Microsoft.AspNetCore.Mvc.Razor.Compilation.MetadataReferenceFeature();
            //pm.PopulateFeature(feature);

            // 
            //System.Reflection.Assembly entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
            //Microsoft.Extensions.DependencyModel.DependencyContext ctx =
            //    Microsoft.Extensions.DependencyModel.DependencyContext.Load(entryAssembly);

            //System.Collections.Generic.IEnumerable<AssemblyItem> assemblyItems;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    } // public class AspNetMvcApplicationStartup
} // namespace Impulse.Applications