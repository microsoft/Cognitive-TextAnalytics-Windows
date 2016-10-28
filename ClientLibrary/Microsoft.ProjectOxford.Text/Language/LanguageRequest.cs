using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageRequest
    {
        public LanguageRequest()
        {
            this.Documents = new List<Document>();
            this.NumberOfLanguagesToDetect = 1;
        }

        [JsonProperty("documents")]
        public List<Document> Documents { get; set; }

        [JsonIgnore]
        public int NumberOfLanguagesToDetect{ get; set; }

    }
}
