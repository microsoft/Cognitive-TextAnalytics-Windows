using Newtonsoft.Json;
using System;

namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Topic result object.
    /// </summary>
    public class TopicResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        /// <value>
        /// The score.
        /// </value>
        [JsonProperty("score")]
        public float Score { get; set; }

        /// <summary>
        /// Gets or sets the key phrase.
        /// </summary>
        /// <value>
        /// The key phrase.
        /// </value>
        [JsonProperty("keyPhrase")]
        public string KeyPhrase { get; set; }

        #endregion Properties
    }
}
