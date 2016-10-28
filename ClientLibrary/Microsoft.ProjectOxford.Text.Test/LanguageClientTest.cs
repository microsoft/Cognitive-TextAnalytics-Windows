using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;

namespace Microsoft.ProjectOxford.Text.Test
{
    [TestClass]
    public class LanguageClientTest
    {
        private string apiKey = "";

        [TestInitialize]
        public void Intialize()
        {
            apiKey = ConfigurationManager.AppSettings["apiKey"];
        }

        [TestMethod]
        [TestCategory("Language Detection")]
        public void GetLanguagesTest_OneLangage()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend" };

            var request = new LanguageRequest();
            request.Documents.Add(doc01);

            var client = new LanguageClient(this.apiKey);
            var response = client.GetLanguages(request);

            Assert.AreEqual("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[0].DetectedLanguages[0].Score);
        }

        [TestMethod]
        [TestCategory("Language Detection")]
        public void GetLanguagesTest_TwoLangages()
        {
            var doc01 = new Document() { Id = "TEST001", Text = "Hello my friend." };
            var doc02 = new Document() { Id = "TEST002", Text = "Hola mi amigo" };

            var request = new LanguageRequest();
            request.NumberOfLanguagesToDetect = 2;
            request.Documents.Add(doc01);
            request.Documents.Add(doc02);

            var client = new LanguageClient(this.apiKey);
            var response = client.GetLanguages(request);

            Assert.AreEqual("en", response.Documents[0].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("English", response.Documents[0].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[0].DetectedLanguages[0].Score);

            Assert.AreEqual("es", response.Documents[1].DetectedLanguages[0].Iso639Name);
            Assert.AreEqual("Spanish", response.Documents[1].DetectedLanguages[0].Name);
            Assert.AreEqual(1.0, response.Documents[1].DetectedLanguages[0].Score);
        }
    }
}
