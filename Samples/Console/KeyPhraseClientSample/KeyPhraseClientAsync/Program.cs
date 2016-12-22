using Microsoft.ProjectOxford.Text.KeyPhrase;
using System;
using System.Threading.Tasks;

namespace KeyPhraseClientAsync
{
    class Program
    {
        static async Task MainAsync()
        {
            var apiKey = "YOUR-TEXT-ANALYTICS-API-SUBSCRIPTION-KEY";

            var document = new KeyPhraseDocument()
            {
                Id = "YOUR-UNIQUE-ID",
                Text = "YOUR-TEXT",
                Language = "en"
            };

            var request = new KeyPhraseRequest();
            request.Documents.Add(document);

            var client = new KeyPhraseClient(apiKey);

            var response = await client.GetKeyPhrasesAsync(request);

            foreach (var doc in response.Documents)
            {
                Console.WriteLine("Document Id: {0}", doc.Id);

                foreach (var keyPhrase in doc.KeyPhrases)
                {
                    Console.WriteLine("   Key Phrase: {0}", keyPhrase);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
    }
}
