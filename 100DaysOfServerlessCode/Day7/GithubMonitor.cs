using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _100DaysOfServerlessCode.Day7
{
    public static class GithubMonitor
    {
        [FunctionName("GithubMonitor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string responseMessage = "";
            try
            {
                BL.CallExecute();
                responseMessage = "Mail sent";
            }
            catch (Exception ex)
            {
                log.LogInformation(ex.StackTrace.ToString());
                responseMessage = "Mail not sent";
            }
            return new OkObjectResult(responseMessage);
        }
    }
}
