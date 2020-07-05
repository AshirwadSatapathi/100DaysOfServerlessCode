using System;
using System.Collections.Generic;
using System.Text;
using Azure;
using System.Globalization;
using Azure.AI.TextAnalytics;

namespace _100DaysOfServerlessCode.Day6
{
    class BL
    {
        private static readonly AzureKeyCredential credentials = new AzureKeyCredential("2c3ee45d7dca4bc5a4b343162916ea4c");
        private static readonly Uri endpoint = new Uri("https://textanalyticsservicedemo.cognitiveservices.azure.com/");

        public static string SentimentScore(string Message)
        {
            var client = new TextAnalyticsClient(endpoint, credentials);
            string inputText = Message;
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(inputText);

            string responseMessage = $"Document sentiment: {documentSentiment.Sentiment}" +
                $"\nText: {documentSentiment.ConfidenceScores.Positive}" +
                $"\nText: {documentSentiment.ConfidenceScores.Negative}" +
                $"\nText: {documentSentiment.ConfidenceScores.Neutral}";


            return responseMessage;

        }
    }
}