using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _100DaysOfServerlessCode.Day3
{
    public static class HttpTriggerCeaserCipher
    {
        [FunctionName("HttpTriggerCeaserCipher")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string message = req.Query["message"];
            string key = req.Query["key"];
            string operation = req.Query["Operation"];
            
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            message = message ?? data?.message;
            key = key ?? data?.key;
            operation = operation ?? data.operation;

            string responseMessage = "";

            if (string.IsNullOrEmpty(operation))
            {
                responseMessage = "Please pass the operation you intend to perform.";
            }
            else
            {
                if (string.IsNullOrEmpty(message) && string.IsNullOrEmpty(key))
                {
                    responseMessage = "Please pass the message and key.";
                }
                if (string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(key))
                {
                    responseMessage = "Please pass the message.";
                }
                if (!string.IsNullOrEmpty(message) && string.IsNullOrEmpty(key))
                {
                    responseMessage = "Please pass the key.";
                }
                if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(key))
                {
                    if (operation == "Encrypt")
                    {
                        responseMessage = $"Encrypted message for {message} is {BL.Encryption(message, key)}";
                    }
                    else if(operation == "Decrypt"){
                        responseMessage = $"Decrypted message for {message} is {BL.Decryption(message, key)}";
                    }
                    else
                    {
                        responseMessage = "Please Select a valid operation.";
                    }

                }
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
