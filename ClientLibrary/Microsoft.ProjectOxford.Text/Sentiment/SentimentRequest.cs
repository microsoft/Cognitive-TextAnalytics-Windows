using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;

namespace Microsoft.ProjectOxford.Text.Sentiment
{
    /// <summary>
    /// Request for interacting with the Text Analytics sentiment analysis API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class SentimentRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SentimentRequest"/> class.
        /// </summary>
        public SentimentRequest()
        {
            this.Documents = new List<IDocument>();
        }

        #endregion  Constructors
    }
}
