using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentMinSizeException : ApplicationException
    {
        public DocumentMinSizeException(string documentId, int documentSize, int minimumDocumentSize)
        {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MinimumDocumentSize = minimumDocumentSize;
        }

        public string DocumentId { get; set; }

        public int DocumentSize { get; set; }

        public int MinimumDocumentSize { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document {0} is {1} bytes. Documents have a minimum size of {2} bytes.", DocumentId, DocumentSize, MinimumDocumentSize);
            }
        }
    }
}
