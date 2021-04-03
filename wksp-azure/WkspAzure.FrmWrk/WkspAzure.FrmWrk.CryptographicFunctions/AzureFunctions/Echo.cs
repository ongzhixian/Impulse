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

    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            try
            {
                Dictionary<string, string> queryStrings = req.QueryStrings();
                dynamic data = await req.DataAsync(log);

                bool definedInQueryString = queryStrings.ContainsKey("message");
                bool definedInBody = (null != data?.message);

                log.Info($"PARAMS: definedInQueryString:[{definedInQueryString}] definedInBody:[{definedInBody}] method:[{req.Method}]");

                if (!definedInQueryString && !definedInBody)
                {
                    return ResponseMessage(log, HttpStatusCode.OK, "NG", "No message parameter");
                }

                if (definedInQueryString && definedInBody)
                {
                    if (HttpMethod.Get == req.Method)
                    {
                        return ResponseMessage(log, HttpStatusCode.OK, "OK", $"{queryStrings["message"]}");
                    }

                    if (HttpMethod.Post == req.Method)
                    {
                        return ResponseMessage(log, HttpStatusCode.OK, "OK", $"{data?.message}");
                    }
                }

                if (definedInQueryString)
                {
                    return ResponseMessage(log, HttpStatusCode.OK, "OK", $"{queryStrings["message"]}");
                }

                if (definedInBody)
                {
                    return ResponseMessage(log, HttpStatusCode.OK, "OK", $"{data?.message}");
                }

                return ResponseMessage(log, HttpStatusCode.OK, "NG", "Invalid parameters");
            }
            catch (Exception ex)
            {
                log.Error(nameof(Echo), ex, "WkspAzure.FrmWrk.CryptographicFunctions");

                throw;
            }
        }

        private static HttpResponseMessage ResponseMessage(TraceWriter log, HttpStatusCode httpStatusCode, string status, string description)
        {
            string result = JsonConvert.SerializeObject(new
            {
                timestamp = DateTime.UtcNow.ToString("u"),
                httpStatusCode,
                status,
                description
            });

            log.Info(result);

            return new HttpResponseMessage(httpStatusCode)
            {
                Content = new StringContent(result)
            };
        }
    }
}
