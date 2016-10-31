using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentCollectionMaxDocumentException : ApplicationException
    {
        public DocumentCollectionMaxDocumentException(int documentCount, int maximumDocumentCount)
        {
            this.DocumentCount = documentCount;
            this.MaximumDocumentCount = maximumDocumentCount;
        }

        public int DocumentCount { get; set; }
        public int MaximumDocumentCount { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document collection has [0} documents. The maximum number of documents for a collection is {1}.", DocumentCount, MaximumDocumentCount);
            }
        }
    }
}
