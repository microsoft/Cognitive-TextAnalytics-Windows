using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Request for interacting with the Text Analytics topic detection API.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.Core.TextRequest" />
    public class TopicRequest : TextRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicRequest"/> class.
        /// </summary>
        public TopicRequest()
        {
            this.Documents = new List<IDocument>();
            this.StopWords = new List<string>();
            this.TopicsToExclude = new List<string>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the stop words.
        /// </summary>
        /// <value>
        /// The stop words.
        /// </value>
        [JsonProperty("stopWords")]
        public List<string> StopWords { get; set; }

        /// <summary>
        /// Gets or sets the topics to exclude.
        /// </summary>
        /// <value>
        /// The topics to exclude.
        /// </value>
        [JsonProperty("topicsToExclude")]
        public List<string> TopicsToExclude { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Validates the request.
        /// </summary>
        /// <exception cref="DocumentCollectionMinDocumentException">Thrown when the minimum number of documents is not met.</exception>
        /// <exception cref="DocumentIdRequiredException">Thrown when a document id is not provided.</exception>
        /// <exception cref="DocumentCollectionDuplicateIdException">Thrown when the same id is used on multiple documents.</exception>
        /// <exception cref="DocumentMinSizeException">Thrown when the minimum size of a document is not met.</exception>
        /// <exception cref="DocumentMaxSizeException">Thrown when the maximum size of a document is exceeded.</exception>
        /// <exception cref="DocumentCollectionMaxSizeException">Thrown when the maximum size of all document is exceeded.</exception>
        public new void Validate()
        {
            //max document size is 30KB
            int maxDocumentSize = 10240 * 3;

            //max collection size is 30MB
            int maxCollectionSize = 1024 * 1024 * 30;

            //must have at least 100 document
            if (this.Documents == null || this.Documents.Count < 100)
            {
                throw new DocumentCollectionMinDocumentException(this.Documents.Count, 100);
            }

            var collectionSize = 0;
            var documentIds = new List<string>();

            foreach (var document in this.Documents)
            {
                //document must have an id
                if (string.IsNullOrWhiteSpace(document.Id))
                {
                    throw new DocumentIdRequiredException();
                }

                //document id's must be unique
                if (documentIds.Contains(document.Id))
                {
                    throw new DocumentCollectionDuplicateIdException(document.Id);
                }
                else
                {
                    documentIds.Add(document.Id);
                }

                //document size must be greater than 0 and less than or equal to 30KB
                if (document.Size <= 0)
                {
                    throw new DocumentMinSizeException(document.Id, document.Size, 1);
                }

                if (document.Size > maxDocumentSize)
                {
                    throw new DocumentMaxSizeException(document.Id, document.Size, maxDocumentSize);
                }

                collectionSize = collectionSize + document.Size;
            }

            //total size of all documents cannot exceed 30MB
            if (collectionSize > maxCollectionSize)
            {
                throw new DocumentCollectionMaxSizeException(collectionSize, maxCollectionSize);
            }

            #endregion Methods
        }
    }
}