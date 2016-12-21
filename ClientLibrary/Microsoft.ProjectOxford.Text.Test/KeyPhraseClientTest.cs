using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.KeyPhrase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Microsoft.ProjectOxford.Text.Test
{
    /// <summary>
    /// Unit tests for the KeyPhraseClient class.
    /// </summary>
    /// <seealso cref="Microsoft.ProjectOxford.Text.KeyPhrase.KeyPhraseClient" />
    [TestClass]
    public class KeyPhraseClientTest
    {
        #region Fields

        private string apiKey = "";

        #endregion Fields

        #region Test Inititalization

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
        /// Unit test of the GetKeyPhrases method.
        /// </summary>
        [TestMethod]
        [TestCategory("Key Phrase Detection")]
        public void GetKeyPhrases()
        {
            var text = "Hi. How are you? I am fine. How are you? I am good. How are you?";
            var doc = new KeyPhraseDocument() { Id = "TEST001", Text = text, Language = "en" };

            var request = new KeyPhraseRequest();
            request.Documents.Add(doc);

            var client = new KeyPhraseClient(this.apiKey);
            var response = client.GetKeyPhrases(request);

            var actual = response.Documents[0].KeyPhrases[0];
            var expected = "Hi";

            Assert.AreEqual(expected, actual);
        }

        #endregion Test Methods
    }
}
