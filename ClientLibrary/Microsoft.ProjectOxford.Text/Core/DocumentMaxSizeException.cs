using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentMaxSizeException : ApplicationException
    {
        public DocumentMaxSizeException(string documentId, int documentSize, int maximumDocumentSize)
        {
            this.DocumentId = documentId;
            this.DocumentSize = documentSize;
            this.MaximumDocumentSize = maximumDocumentSize;
        }

        public string DocumentId { get; set; }

        public int DocumentSize { get; set; }

        public int MaximumDocumentSize { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document {0} is {1} bytes. Documents have a maximum size of {2} bytes.", DocumentId, DocumentSize, MaximumDocumentSize);
            }
        }
    }
}
