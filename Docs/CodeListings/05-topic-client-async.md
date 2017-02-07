```cs
using Microsoft.ProjectOxford.Text.Topic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TopicClientAsync
{
    class Program
    {
        static async Task MainAsync()
        {
            var apiKey = "YOUR-TEXT-ANALYTICS-API-SUBSCRIPTION-KEY";

            var randomText = new RandomText();

            var request = new TopicRequest();

            for (int i = 1; i <= 200; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = randomText.Next() });
            }

            var client = new TopicClient(apiKey);
            var opeationUrl = await client.StartTopicProcessingAsync(request);
            var response = await client.GetTopicResponseAsync(opeationUrl);

            foreach (var topic in response.OperationProcessingResult.Topics)
            {
                Console.WriteLine("{0} | {1}", topic.KeyPhrase, topic.Score);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }

    internal class RandomText
    {
        private Random _random;
        private List<string> _text;

        public RandomText()
        {
            _random = new Random();

            _text = new List<string>();

            _text.Add("I had a wonderful experience! The rooms were wonderful and the staff were helpful.");
            _text.Add("I had a terrible time at the hotel. The staff were rude and the food was awful.");
        }

        public string Next()
        {
            var index = _random.Next(0, 2);
            return _text[index];
        }
    }
}
```
