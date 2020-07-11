using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _100DaysOfServerlessCode.Day11
{
    class Business
    {
        public static void CallExecute()
        {
            Execute().Wait();
        }

        private static async Task Execute()
        {
            var apiKey = "<api-key>";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("ashirwad.satapathi@outlook.com"));
            msg.AddTo(new EmailAddress("ashirwadsatapathi.aim@gmail.com", "Ashirwad"));

            var cc_emails = new List<EmailAddress>
            {
                new EmailAddress("ashirwad@abc.com","test 1"),
                new EmailAddress("abc@gmail.com","test 2")
            };

            msg.AddCcs(cc_emails);
            var bcc_emails = new List<EmailAddress> { 
                new EmailAddress("bcd@gmail.com","test 3"),
                new EmailAddress("cde@gmail.com","test 4")
            };

            msg.AddBccs(bcc_emails);

            msg.SetTemplateId("d-3e97f42b3efc437cb23f754664d41fca");



            var dynamicTemplateData = new ExampleTemplateData
            {
                Subject = "100DaysOfServerlessCode",
            };

            msg.SetTemplateData(dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);

        }

        private class ExampleTemplateData
        {
            [JsonProperty("subject")]
            public string Subject { get; set; }

        }
    }
}
