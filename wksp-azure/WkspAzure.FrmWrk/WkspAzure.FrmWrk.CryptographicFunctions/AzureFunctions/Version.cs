namespace WkspAzure.FrmWrk.CryptographicFunctions
{
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class Version
    {
        [FunctionName("Version")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            try
            {
                Dictionary<string, string> queryStrings = req.QueryStrings();

                dynamic data = await req.DataAsync();

                string result = JsonConvert.SerializeObject(new
                {
                    timestamp = DateTime.UtcNow.ToString("u"),
                    httpStatusCode = HttpStatusCode.OK,
                    status = "OK",
                    version = "1.0.0",
                });

                log.Info(result);
                
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(result)
                };

            }
            catch (System.Exception ex)
            {
                log.Error(nameof(Version), ex, "WkspAzure.FrmWrk.CryptographicFunctions");

                throw;
            }
        }
    }
}
