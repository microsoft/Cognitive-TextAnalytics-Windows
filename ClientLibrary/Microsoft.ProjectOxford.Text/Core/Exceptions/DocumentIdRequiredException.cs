using System;

namespace Microsoft.ProjectOxford.Text.Core
{
    /// <summary>
    /// Exception thrown when a document id is not provided.
    /// </summary>
    /// <seealso cref="System.ApplicationException" />
    public class DocumentIdRequiredException : ApplicationException
    {
        #region Properties

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return "A document's Id property is required.";
            }
        }

        #endregion Properties
    }
}
