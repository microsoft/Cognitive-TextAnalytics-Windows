using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageRequest : TextRequest
    {
        public LanguageRequest() : base()
        {
            this.NumberOfLanguagesToDetect = 1;
        }

        [JsonIgnore]
        public int NumberOfLanguagesToDetect{ get; set; }

    }
}
