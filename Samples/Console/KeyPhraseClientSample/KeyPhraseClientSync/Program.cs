using Microsoft.ProjectOxford.Text.KeyPhrase;
using System;

namespace KeyPhraseClientSync
{
    class Program
    {
        static void Main(string[] args)
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

            var response = client.GetKeyPhrases(request);

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
    }
}
