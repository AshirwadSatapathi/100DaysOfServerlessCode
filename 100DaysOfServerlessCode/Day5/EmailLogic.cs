using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace _100DaysOfServerlessCode.Day5
{
    class EmailLogic
    {
        public static void SendEMail(string senderEmail, string recieverEmail, string subject, string plainTextContent, string htmlContent)
        {
            Execute(senderEmail, recieverEmail, subject, plainTextContent, htmlContent).Wait();
        }

        private static async Task Execute(string senderEmail, string recieverEmail, string subject, string plainTextContent, string htmlContent)
        {
            var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail, "Ashirwad");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(recieverEmail, "Ashirwad Satapathi");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);



            var response = await client.SendEmailAsync(msg);
        }
    }
}
