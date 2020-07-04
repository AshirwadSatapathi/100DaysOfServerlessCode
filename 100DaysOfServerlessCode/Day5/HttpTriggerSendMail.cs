using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace _100DaysOfServerlessCode.Day5
{
    public static class HttpTriggerSendMail
    {
        [FunctionName("HttpTriggerSendMail")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string fromEmail = req.Query["fromEmail"];
            string toEmail = req.Query["toEmail"];
            string subject = req.Query["subject"];
            string plainText = req.Query["plainText"];
            string htmlContent = req.Query["htmlContent"];
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;
            fromEmail = fromEmail ?? data?.fromEmail;
            toEmail = toEmail ?? data?.toEmail;
            subject = subject ?? data?.subject;
            plainText = plainText ?? data?.plainText;
            htmlContent = htmlContent ?? data?.htmlContent;

            string responseMessage = "";

            try
            {
                EmailLogic.SendEMail(fromEmail, toEmail, subject, plainText, htmlContent);
                responseMessage = "Mail Sent";
            }
            catch{
                responseMessage = "Mail Not Sent";
            }

            return new OkObjectResult(responseMessage);
        }
    }
}
