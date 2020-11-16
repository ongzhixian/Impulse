using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Razor.Language.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Impulse.Applications
{
    public class RazorApplication : IApplication
    {
        public Task RunAsync(string[] args)
        {
            string targetProjectDirectory = AppContext.BaseDirectory;
            string rootNamespace = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetTempFileName()).ToLowerInvariant();

            RazorProjectFileSystem fileSystem = RazorProjectFileSystem.Create(targetProjectDirectory);
            RazorProjectEngine projectEngine = RazorProjectEngine.Create(RazorConfiguration.Default, fileSystem, builder =>
            {
                builder
                    .SetNamespace(rootNamespace)
                    .SetBaseType("Microsoft.Extensions.RazorViews.BaseView")
                    .ConfigureClass((document, @class) =>
                    {
                        @class.ClassName = Path.GetFileNameWithoutExtension(document.Source.FilePath);
                        @class.Modifiers.Clear();
                        @class.Modifiers.Add("internal");
                    });

                FunctionsDirective.Register(builder);
                InheritsDirective.Register(builder);
                SectionDirective.Register(builder);

                //builder.Features.Add()
                //builder.Features.Add(new SuppressChecksumOptionsFeature());
                //builder.Features.Add(new SuppressMetadataAttributesFeature());

                // configure is always null
                //if (configure != null)
                //{
                //    configure(builder);
                //}

                builder.AddDefaultImports(@"
@using System
@using System.Threading.Tasks");

            });

            return Task.Run(() => {
                Console.WriteLine("Do nothing");
            });

        } // public void Run(string[] args)


    } // public class RazorApplication : IApplication
} // namespace Impulse.Applications
