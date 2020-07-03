using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;

namespace _100DaysOfServerlessCode.Day4
{
    public static class HttpTriggerStringOperation
    {
        [FunctionName("HttpTriggerStringOperation")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string message = req.Query["message"];
            string operation = req.Query["operation"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            message = message ?? data?.message;
            operation = operation ?? data?.operation;

            string responseMessage = "";
            if(!string.IsNullOrEmpty(operation))
            {
                if(operation.ToLower() == "reverse")
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        
                        responseMessage = $"The reverse of {message} is {Reverse(message)}";
                    }
                    else
                    {
                        responseMessage = "Please pass the message";
                    }
                }
                else if (operation.ToLower() == "lower")
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        responseMessage = $"The lower case form of {message} is {message.ToLower()}";
                    }
                    else
                    {
                        responseMessage = "Please pass the message";
                    }
                }
                else if (operation.ToLower() == "upper")
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        responseMessage = $"The upper case form of {message} is {message.ToUpper()}";
                    }
                    else
                    {
                        responseMessage = "Please pass the message";
                    }
                }
                else if (operation.ToLower() == "length")
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        responseMessage = $"The length of {message} is {message.Length}";
                    }
                    else
                    {
                        responseMessage = "Please pass the message";
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        responseMessage = "Please select a valid operaiton";
                    }
                    else
                    {
                        responseMessage = "Please pass valid operation and message";
                    }
                    
                }
            }

            
            return new OkObjectResult(responseMessage);
        }
        public static string Reverse(string text)
        {
            if (text == null) return null;
 
            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
    }
}
