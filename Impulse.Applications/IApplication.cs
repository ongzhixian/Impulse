namespace Impulse.Applications
{
    using System.Threading.Tasks;
    public interface IApplication
    {
        Task RunAsync(string[] args);

        // Reference this for Microsoft.AspNetCore 2.2.0
        // https://github.com/dotnet/aspnetcore/tree/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b

        // Reference this for Microsoft.AspNetCore.App 2.1.1
        // https://github.com/dotnet/aspnetcore/tree/4cceccd5689ebf7712c03789df536cbb4cfc2efc/src/Mvc
    }
}
