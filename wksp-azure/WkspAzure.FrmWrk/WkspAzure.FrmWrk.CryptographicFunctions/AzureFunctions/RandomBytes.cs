namespace WkspAzure.FrmWrk.CryptographicFunctions
{
    using Impulse.NetFrmWrk.Cryptography;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class RandomBytes
    {
        static ICryptographyService cryptographyService;

        static RandomBytes()
        {
            cryptographyService = new CryptographyService();
        }

        [FunctionName("RandomBytes")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req,
            TraceWriter log)
        {
            try
            {
                Dictionary<string, string> queryStrings = req.QueryStrings();

                dynamic data = await req.DataAsync(log);

                bool definedInQueryString = queryStrings.ContainsKey("numberofBytes");
                bool definedInBody = (null != data?.numberOfBytes);

                string numberOfBytesString = null;
                int numberOfBytes;

                log.Info($"PARAMS: definedInQueryString:[{definedInQueryString}] definedInBody:[{definedInBody}] method:[{req.Method}]");

                if (!definedInQueryString && !definedInBody)
                {
                    return ResponseMessage(log, HttpStatusCode.OK, "NG", "No numberofBytes parameter");
                }

                if (definedInQueryString && definedInBody && HttpMethod.Get == req.Method)
                {
                    log.Info("Assignment scenario 1");
                    numberOfBytesString = queryStrings["numberOfBytes"];
                }

                if (definedInQueryString && definedInBody && HttpMethod.Post == req.Method)
                {
                    log.Info("Assignment scenario 2");
                    numberOfBytesString = data?.numberOfBytes;
                }

                if (definedInQueryString)
                {
                    log.Info("Assignment scenario 3");
                    numberOfBytesString = queryStrings["numberOfBytes"];
                }

                if (definedInBody)
                {
                    log.Info("Assignment scenario 4");
                    numberOfBytesString = data?.numberOfBytes;
                }

                log.Info($"Number of bytes {numberOfBytesString}");

                if (!int.TryParse(numberOfBytesString, out numberOfBytes))
                {
                    return ResponseMessage(log, HttpStatusCode.OK, "NG", $"Invalid numberOfBytesString {numberOfBytesString}");
                }

                cryptographyService.GetRandomBytes(numberOfBytes).AsBase64String();

                string result = JsonConvert.SerializeObject(new
                {
                    timestamp = DateTime.UtcNow.ToString("u"),
                    httpStatusCode = HttpStatusCode.OK,
                    status = "OK",
                    bytesInBase64 = cryptographyService.GetRandomBytes(numberOfBytes).AsBase64String()
                });

                log.Info(result);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(result)
                };
            }
            catch (System.Exception ex)
            {
                log.Error(nameof(RandomBytes), ex, "WkspAzure.FrmWrk.CryptographicFunctions");

                throw;
            }
        }

        private static HttpResponseMessage ResponseMessage(TraceWriter log, HttpStatusCode httpStatusCode, string status, string description)
        {
            string result = JsonConvert.SerializeObject(new
            {
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
