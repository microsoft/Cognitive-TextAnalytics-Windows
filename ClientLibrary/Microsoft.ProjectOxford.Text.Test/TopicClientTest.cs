using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Topic;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the TopicClient class.
    /// </summary>
    [TestClass]
    public class TopicClientTest
    {
        #region Fields

        private string apiKey = "";

        #endregion Fields

        #region Test Initialization

        /// <summary>
        /// Intializes this instance.
        /// </summary>
        [TestInitialize]
        public void Intialize()
        {
            apiKey = ConfigurationManager.AppSettings["apiKey"];
        }

        #endregion Test Initialization

        #region Test Methods

        /// <summary>
        /// Unit test of the Validate method for the minimum number of documents in a collection.
        /// </summary>
        [TestMethod]
        [TestCategory("Topic Detection")]
        [ExpectedException(typeof(DocumentCollectionMinDocumentException))]
        public void ValidateTest_MinDocumentCollectionCount()
        {
            var request = new TopicRequest();
            request.Validate();
        }

        #endregion Test Methods
    }
}
