using Newtonsoft.Json;
using System;

namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Topic response object.
    /// </summary>
    public class TopicResponse
    {
        #region Properties

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the date created.
        /// </summary>
        /// <value>
        /// The date created.
        /// </value>
        [JsonProperty("createdDateTime")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the type of the operation.
        /// </summary>
        /// <value>
        /// The type of the operation.
        /// </value>
        [JsonProperty("operationType")]
        public string OperationType { get; set; }

        /// <summary>
        /// Gets or sets the operation processing result.
        /// </summary>
        /// <value>
        /// The operation processing result.
        /// </value>
        [JsonProperty("operationProcessingResult")]
        public TopicOperationProcessingResult OperationProcessingResult { get; set; }

        #endregion Properties
    }
}
