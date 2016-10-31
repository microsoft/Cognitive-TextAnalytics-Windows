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
        public void ValidateTest_MinDocuments()
        {
            var request = new MockRequest();
            request.Validate();
        }

        [TestMethod]
        [TestCategory("Request Validation")]
        [ExpectedException(typeof(DocumentCollectionMaxDocumentException))]
        public void ValidateTest_MaxDocuments()
        {
            var request = new MockRequest();

            for(int i = 1; i<=1001; i++)
            {
                request.Documents.Add(new Document() { Id = i.ToString(), Text = "test test test" });
            }

            request.Validate();
        }
    }

    public class MockRequest : TextRequest { }
}
