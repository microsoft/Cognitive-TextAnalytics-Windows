using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Language
{
    public class LanguageRequest
    {
        public LanguageRequest()
        {
            this.NumberOfLanguagesToDetect = 1;
        }

        public int NumberOfLanguagesToDetect{ get; set; }
    }
}
