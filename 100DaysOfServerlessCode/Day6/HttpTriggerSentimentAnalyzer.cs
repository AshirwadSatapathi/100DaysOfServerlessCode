using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _100DaysOfServerlessCode.Day6
{
    public static class HttpTriggerSentimentAnalyzer
    {
        [FunctionName("HttpTriggerSentimentAnalyzer")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string message = req.Query["message"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            message = message ?? data?.message;

            string responseMessage = string.IsNullOrEmpty(message)
                ? "Pass the message to know about the sentiment score of the message."
                : $"{BL.SentimentScore(message)}";

            return new OkObjectResult(responseMessage);
        }
    }
}
