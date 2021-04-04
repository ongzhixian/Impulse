namespace WkspAzure.FrmWrk.CryptographicFunctions
{
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Returns query string name-value pairs as Dictionary&lt;string, string&gt;
        /// </summary>
        /// <param name="req">HttpRequestMessage</param>
        /// <returns>Dictionary&lt;string, string&gt;</returns>
        public static Dictionary<string, string> QueryStrings(this HttpRequestMessage req)
        {
            try
            {
                return req.GetQueryNameValuePairs().ToDictionary(
                        kv => kv.Key,
                        kv => kv.Value,
                        StringComparer.OrdinalIgnoreCase
                    );
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static async Task<dynamic> DataAsync(this HttpRequestMessage req)
        {
            return await DataAsync(req, null);
        }

        public static async Task<dynamic> DataAsync(this HttpRequestMessage req, TraceWriter log = null)
        {
            try
            {
                string requestBody = await req.Content.ReadAsStringAsync();

                log?.Info($"requestBody {requestBody}");

                return JsonConvert.DeserializeObject(requestBody);
            }
            catch (Exception ex)
            {
                log?.Error("DataSync error", ex);

                throw;
            }
        }
    }
}
