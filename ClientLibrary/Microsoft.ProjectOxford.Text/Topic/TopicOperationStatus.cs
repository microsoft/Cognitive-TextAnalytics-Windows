namespace Microsoft.ProjectOxford.Text.Topic
{
    /// <summary>
    /// Status of operation submitted for document detection.
    /// </summary>
    public enum TopicOperationStatus
    {
        /// <summary>
        /// Opeation not started
        /// </summary>
        NotStarted,

        /// <summary>
        /// Operation is running
        /// </summary>
        Running,

        /// <summary>
        /// Operation failed
        /// </summary>
        Failed,

        /// <summary>
        /// Operation cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        /// Operation succeeded
        /// </summary>
        Succeeded
    }
}
