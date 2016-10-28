using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageResponseDocument
    {
        public LanguageResponseDocument()
        {
            this.DetectedLanguages = new List<DetectedLanguage>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("detectedLanguages")]
        public List<DetectedLanguage> DetectedLanguages { get; set; }
    }
}
