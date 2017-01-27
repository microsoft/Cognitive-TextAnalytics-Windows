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

        /// <summary>
        /// Unit test of the Validate method for duplicate document identifiers.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionDuplicateIdException))]
        public void ValidateTest_DuplicateDocumentId()
        {
            var request = new TopicRequest();

            for (int i = 1; i <= 101; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = "01", Text = "doc1" });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for document identifier.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentIdRequiredException))]
        public void ValidateTest_DocumentIdRequired()
        {
            var request = new TopicRequest();

            for (int i = 1; i <= 101; i++)
            {
                request.Documents.Add(new TopicDocument() { Text = "doc1" });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the minimum document size.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMinSizeException))]
        public void ValidateTest_MinDocumentSize()
        {
            var request = new TopicRequest();

            for (int i = 1; i <= 101; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString() });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum document size.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMaxSizeException))]
        public void ValidateTest_MaxDocumentSize()
        {
            int count = 10241 * 3;
            var text = new string('*', count);

            var request = new TopicRequest();

            for (int i = 1; i <= 101; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = text });
            }

            request.Validate();
        }

        /// <summary>
        /// Unit test of the Validate method for the maximum size of a document collections.
        /// </summary>
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxSizeException))]
        public void ValidateTest_MaxDocumentCollectionSize()
        {
            var count = 1024 * 31;
            var text = new string('*', 1024);

            var request = new TopicRequest();

            for (int i = 1; i <= count; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = text });
            }

            request.Validate();
        }

        #endregion Test Methods
    }
}
