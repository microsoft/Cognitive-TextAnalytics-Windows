using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core.Exceptions
{
    /// <summary>
    /// Exception thrown when a document's language is not provided.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class LanguageRequiredException : ApplicationException
    {
        #region Properties

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return "A document's language property is required.";
            }
        }

        #endregion Properties
    }
}
