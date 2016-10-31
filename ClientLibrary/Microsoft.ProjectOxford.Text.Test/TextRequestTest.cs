using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.ProjectOxford.Text.Core;

namespace Microsoft.ProjectOxford.Text.Test
{
    [TestClass]
    public class TextRequestTest
    {
        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMinDocumentException))]
        public void ValidateTest_MinDocumentCollectionCount()
        {
            var request = new MockRequest();
            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxDocumentException))]
        public void ValidateTest_MaxDocumentCollectionCount()
        {
            var request = new MockRequest();

            for (int i = 1; i <= 1001; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = "test test test" });
            }

            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxSizeException))]
        public void ValidateTest_MaxDocumentCollectionSize()
        {
            var text = new string('*', 10240);

            var request = new MockRequest();

            for (int i = 1; i <= 1000; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = text });
            }

            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentIdRequiredException))]
        public void ValidateTest_DocumentIdRequired()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Text = "doc1" });

            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionDuplicateIdException))]
        public void ValidateTest_DuplicateDocumentId()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "01", Text = "doc1" });
            request.Documents.Add(new Document() { Id = "01", Text = "doc2" });

            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMinSizeException))]
        public void ValidateTest_MinDocumentSize()
        {
            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001" });

            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentMaxSizeException))]
        public void ValidateTest_MaxDocumentSize()
        {
            var text = new string('*', 10241);

            var request = new MockRequest();

            request.Documents.Add(new Document() { Id = "001", Text = text });

            request.Validate();
        }
    }

    public class MockRequest : TextRequest { }
}
