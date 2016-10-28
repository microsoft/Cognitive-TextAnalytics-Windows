using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageResponse
    {
        public LanguageResponse()
        {
            this.Documents = new List<LanguageResponseDocument>();
            this.Errors = new List<DocumentError>();
        }

        [JsonProperty("documents")]
        public List<LanguageResponseDocument> Documents { get; set; }

        [JsonProperty("errors")]
        public List<DocumentError> Errors { get; set; }
    }
}
