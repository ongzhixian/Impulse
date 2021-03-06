# Additional dotnet tools

## Restoring tools

dotnet tool restore


## Command-line to install tools

### Resharper (Code-analysis)

dotnet tool install -g JetBrains.ReSharper.GlobalTools


### ML.NET (Machine learning)

(Requires .NET Core 3.1+)
dotnet tool install -g mlnet


### Cake (build tool)

dotnet tool install -g Cake.Tool

dotnet cake --target=Publish


### Templates for GtkSharp

dotnet new --install GtkSharp.Template.CSharp

### Templates for Blazor

dotnet new -i Microsoft.AspNetCore.Blazor.Templates

