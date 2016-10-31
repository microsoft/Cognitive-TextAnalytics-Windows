using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentCollectionDuplicateIdException : ApplicationException
    {
        public DocumentCollectionDuplicateIdException(string documentId)
        {
            this.DocumentId = documentId;
        }

        public string DocumentId { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Multiple documents with the id {0} were found. Document id's must be unique per document.", this.DocumentId);
            }
        }
    }
}
