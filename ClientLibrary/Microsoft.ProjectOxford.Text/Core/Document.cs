using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class Document
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }

        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            this.Text = this.Text.Replace("\"", "");
        }
    }
}
