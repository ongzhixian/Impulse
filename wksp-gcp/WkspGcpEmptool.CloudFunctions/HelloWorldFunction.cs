using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WkspGcpEmptool.CloudFunctions
{
    public class HelloWorld : IHttpFunction
    {
        public async Task HandleAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World!");
        }
    }
}