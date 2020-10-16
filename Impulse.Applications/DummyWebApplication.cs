namespace Impulse.Applications
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.ApplicationParts;
    using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
    using Microsoft.AspNetCore.Mvc.TagHelpers;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;

    public interface IDummyWebApplication : IApplication
    {
    } // public interface IDummyWebApplication : IApplication

    public class DummyWebApplication : IDummyWebApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public DummyWebApplication(ILogger<DummyApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            DemoLogging();


        } // public DummyWebApplication(...)

        public void Run(string[] args)
        {
            Console.WriteLine("Hello from Dummy Web Application");

            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build().Run();

        } // Run(...)

        private void DemoLogging()
        {
            logger.LogTrace("Logging trace");
            logger.LogDebug("Logging debug information.");
            logger.LogInformation("Logging information.");
            logger.LogWarning("Logging warning.");
            logger.LogError("Logging error information.");
            logger.LogCritical("Logging critical information.");
        } // private void DemoLogging()

        private class Startup
        {
            public IConfiguration Configuration { get; }

            public Startup(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                //services.Configure<CookiePolicyOptions>(options =>
                //{
                //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //    options.CheckConsentNeeded = context => true;
                //    options.MinimumSameSitePolicy = SameSiteMode.None;
                //});

                // If we are using `Microsoft.AspNetCore.Mvc` nuget package, then we would be using this
                //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

                // But since we are opting to go as minimal/core as possible (`Microsoft.AspNetCore.Mvc.Core`) 
                //services.AddMvcCore().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

                // 
                // https://github.com/aspnet/Mvc/blob/master/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs
                // https://github.com/aspnet/Mvc/tree/master/src

                IMvcCoreBuilder mvcCoreBuilder = services.AddMvcCore();
                mvcCoreBuilder.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

                mvcCoreBuilder.AddApiExplorer();    // Microsoft.AspNetCore.Mvc.ApiExplorer
                mvcCoreBuilder.AddAuthorization();  // Microsoft.AspNetCore.Authorization

                AddDefaultFrameworkParts(mvcCoreBuilder.PartManager);

                // Order added affects options setup order

                // Default framework order
                mvcCoreBuilder.AddFormatterMappings();
                mvcCoreBuilder.AddViews();
                mvcCoreBuilder.AddRazorViewEngine();
                mvcCoreBuilder.AddRazorPages(); // AddRazorPages
                mvcCoreBuilder.AddCacheTagHelper();

                // +1 order
                mvcCoreBuilder.AddDataAnnotations(); // +1 order

                // +10 order
                mvcCoreBuilder.AddJsonFormatters();

                mvcCoreBuilder.AddCors();

                IMvcBuilder mvcBuilder = new Microsoft.AspNetCore.Mvc.Internal.MvcBuilder(mvcCoreBuilder.Services, mvcCoreBuilder.PartManager);
                

                // Microsoft.AspNetCore.Mvc.Controller is an abstract class as follows:
                // public abstract class Controller : ControllerBase, IActionFilter, IFilterMetadata, IAsyncActionFilter, IDisposable
                // We want to implement our own Microsoft.AspNetCore.Mvc.ControllerBase


                //services.AddControllersWithViews();
                //services.AddRazorPages();

                //Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider modelProvider = new Microsoft.AspNetCore.Mvc.Internal.DefaultApplicationModelProvider

                //Microsoft.AspNetCore.Mvc.ApplicationModels.IControllerModelConvention;

                //Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiActionConventionsApplicationModelConvention
                //Microsoft.AspNetCore.Mvc.WebApiCompatShim.WebApiRoutesApplicationModelConvention
                //Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel model = new Microsoft.AspNetCore.Mvc.ApplicationModels.ControllerModel();
                //Microsoft.AspNetCore.Mvc.ApplicationModels


                //Microsoft.AspNetCore.Hosting.Internal.StartupMethods startupMethods = new Microsoft.AspNetCore.Hosting.Internal.StartupMethods()
                //new ConventionBasedStartup(Microsoft.AspNetCore.Hosting.Internal.StartupMethods)
            }

            private void AddDefaultFrameworkParts(ApplicationPartManager partManager)
            {
                // InputTagHelper needs Microsoft.AspNetCore.Mvc.TagHelpers nuget package
                var mvcTagHelpersAssembly = typeof(InputTagHelper).GetTypeInfo().Assembly;
                if (!partManager.ApplicationParts.OfType<AssemblyPart>().Any(p => p.Assembly == mvcTagHelpersAssembly))
                {
                    partManager.ApplicationParts.Add(new FrameworkAssemblyPart(mvcTagHelpersAssembly));
                }

                var mvcRazorAssembly = typeof(UrlResolutionTagHelper).GetTypeInfo().Assembly;
                if (!partManager.ApplicationParts.OfType<AssemblyPart>().Any(p => p.Assembly == mvcRazorAssembly))
                {
                    partManager.ApplicationParts.Add(new FrameworkAssemblyPart(mvcRazorAssembly));
                }
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
                    app.UseExceptionHandler("/Home/Error");
                    //app.UseHsts();
                }

                //app.UseHttpsRedirection();
                //app.UseStaticFiles();
                //app.UseCookiePolicy();


                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        }

        [DebuggerDisplay("{Name}")]
        private class FrameworkAssemblyPart : AssemblyPart, ICompilationReferencesProvider
        {
            public FrameworkAssemblyPart(Assembly assembly)
                : base(assembly)
            {
            }

            IEnumerable<string> ICompilationReferencesProvider.GetReferencePaths() => Enumerable.Empty<string>();
        }

    } // public class DummyApplication : IDummyApplication


} // namespace Impulse.Applications