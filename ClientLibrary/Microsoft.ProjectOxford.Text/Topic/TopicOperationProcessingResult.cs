using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Topic operation processing result object.
    /// </summary>
    public class TopicOperationProcessingResult
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TopicOperationProcessingResult"/> class.
        /// </summary>
        public TopicOperationProcessingResult()
        {
            this.Topics = new List<TopicResult>();
            this.TopicAssignments = new List<TopicAssignment>();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the topics.
        /// </summary>
        /// <value>
        /// The topics.
        /// </value>
        [JsonProperty("topics")]
        public List<TopicResult> Topics { get; set; }

        /// <summary>
        /// Gets or sets the topic assignments.
        /// </summary>
        /// <value>
        /// The topic assignments.
        /// </value>
        [JsonProperty("topicAssignments")]
        public List<TopicAssignment> TopicAssignments { get; set; }

        #endregion Properties
    }
}
