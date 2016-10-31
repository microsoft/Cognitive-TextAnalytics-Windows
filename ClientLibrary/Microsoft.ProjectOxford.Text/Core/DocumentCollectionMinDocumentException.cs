using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Core
{
    public class DocumentCollectionMinDocumentException : ApplicationException
    {
        public DocumentCollectionMinDocumentException(int documentCount, int MinimumDocumentCount)
        {
            this.DocumentCount = documentCount;
            this.MinimumDocumentCount = MinimumDocumentCount;
        }

        public int DocumentCount { get; set; }
        public int MinimumDocumentCount { get; set; }

        public override string Message
        {
            get
            {
                return string.Format("Document collection has [0} documents. The minimum number of documents for a collection is {1}.", DocumentCount, MinimumDocumentCount);
            }
        }
    }
}
