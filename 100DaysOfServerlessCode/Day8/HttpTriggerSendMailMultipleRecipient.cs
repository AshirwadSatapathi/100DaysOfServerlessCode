using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using _100DaysOfServerlessCode.Day2;

namespace _100DaysOfServerlessCode.Day8
{
    public static class HttpTriggerSendMailMultipleRecipient
    {
        [FunctionName("HttpTriggerSendMailMultipleRecipient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = "";
            try
            {
                Business.CallExecute();
                responseMessage = "Email has been succesfully sent";
            }
            catch
            {
                responseMessage = "Internal Error. Try again.";
            }

            
            return new OkObjectResult(responseMessage);
        }
    }
}
