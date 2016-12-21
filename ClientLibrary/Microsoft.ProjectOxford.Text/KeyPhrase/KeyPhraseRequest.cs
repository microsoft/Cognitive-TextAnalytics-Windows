using Microsoft.ProjectOxford.Text.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.KeyPhrase
{
    /// <summary>
    /// Request for interacting with the Text Analytics key phrase detection API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class KeyPhraseRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyPhraseRequest"/> class.
        /// </summary>
        public KeyPhraseRequest()
        {
            this.Documents = new List<IDocument>();
        }

        #endregion  Constructors
    }
}
