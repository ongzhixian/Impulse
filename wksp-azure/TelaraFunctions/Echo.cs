namespace TelaraFunctions
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                string message = req.Query["message"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                
                message = message ?? data?.message;

                string response = JsonConvert.SerializeObject(new {
                    Timestamp = DateTime.UtcNow.ToString("o"),
                    Amount = 108, 
                    Message = message
                });

                // string response = string.IsNullOrEmpty(message)
                //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                //     : $"Hello, {message}. This HTTP triggered function executed successfully.";

                log.LogInformation($"Result:OK| {response}");

                return new OkObjectResult(response);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
