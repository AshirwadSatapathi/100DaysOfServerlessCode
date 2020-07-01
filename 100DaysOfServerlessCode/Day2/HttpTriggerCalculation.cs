using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _100DaysOfServerlessCode.Day2
{
    public static class HttpTriggerCalculation
    {
        [FunctionName("HttpTriggerCalculation")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string num1 = req.Query["num1"];
            string num2 = req.Query["num2"];
            string operation = req.Query["Operation"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            num1 = num1 ?? data?.num1;
            num2 = num2 ?? data?.num2;
            operation = operation ?? data?.operation;

            string responseMessage = "";

            if (!string.IsNullOrEmpty(num1) && !string.IsNullOrEmpty(num2) && !string.IsNullOrEmpty(operation))
            {
                try
                {
                    float number1 = float.Parse(num1);
                    float number2 = float.Parse(num2);
                    responseMessage = BL.calculate(number1, number2, operation);
                }
                catch
                {
                    responseMessage = "Please enter a valid number for the operation to be performed.";
                }

            }
            else
            {
                responseMessage = "Please send the required parameters";
            }
            


            return new OkObjectResult(responseMessage);
        }
    }
}
