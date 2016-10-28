using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageClient : TextClient
    {
        public LanguageClient(string apiKey) : base(apiKey)
        {
            this.Url = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/languages";
        }

        public LanguageResponse GetLanguages(LanguageRequest request)
        {
            return GetLanguagesAsync(request).Result;
        }

        public async Task<LanguageResponse> GetLanguagesAsync(LanguageRequest request)
        {
            var url = this.Url;

            if (request.NumberOfLanguagesToDetect > 1)
                url = string.Format("{0}?numberOfLanguagesToDetect={1}", url, request.NumberOfLanguagesToDetect);

            var json = JsonConvert.SerializeObject(request);
            var responseJson = await this.SendPostAsync(url, json);
            var response = JsonConvert.DeserializeObject<LanguageResponse>(responseJson);
            return response;
        }
    }
}
