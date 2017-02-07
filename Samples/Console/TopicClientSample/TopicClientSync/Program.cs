using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Topic;

namespace TopicClientSync
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = "";

            var randomText = new RandomText();

            var request = new TopicRequest();

            for (int i = 1; i <= 200; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = randomText.Next() });
            }

            var client = new TopicClient(apiKey);
            var opeationUrl = client.StartTopicProcessing(request);
            var response = client.GetTopicResponse(opeationUrl);

            foreach(var topic in response.OperationProcessingResult.Topics)
            {
                Console.WriteLine("{0} | {1}", topic.KeyPhrase, topic.Score);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }

    internal class RandomText
    {
        #region Fields

        private Random _random;
        private List<string> _text;

        #endregion

        #region Constructors

        public RandomText()
        {
            _random = new Random();

            _text = new List<string>();

            _text.Add("I had a wonderful experience! The rooms were wonderful and the staff were helpful.");
            _text.Add("I had a terrible time at the hotel. The staff were rude and the food was awful.");
        }

        #endregion

        #region Methods

        public string Next()
        {
            var index = _random.Next(0, 2);
            return _text[index];
        }

        #endregion
    }
}
