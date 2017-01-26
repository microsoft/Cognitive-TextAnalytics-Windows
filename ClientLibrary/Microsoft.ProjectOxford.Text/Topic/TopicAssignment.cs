using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Topic assignment.
    /// </summary>
    public class TopicAssignment
    {
        #region Properties

        /// <summary>
        /// Gets or sets the document identifier.
        /// </summary>
        /// <value>
        /// The document identifier.
        /// </value>
        [JsonProperty("documentId")]
        public string DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the topic identifier.
        /// </summary>
        /// <value>
        /// The topic identifier.
        /// </value>
        [JsonProperty("topicId")]
        public Guid TopicId { get; set; }

        /// <summary>
        /// Gets or sets the distance.
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        [JsonProperty("distance")]
        public float Distance { get; set; }

        #endregion Properties
    }
}
