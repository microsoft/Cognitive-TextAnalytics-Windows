using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Topic;
using System.Collections.Generic;

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
        [TestCategory("Topic Detection")]
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
        [TestCategory("Topic Detection")]
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
        [TestCategory("Topic Detection")]
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
        [TestCategory("Topic Detection")]
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
        [TestCategory("Topic Detection")]
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

        /// <summary>
        /// Unit test for StartProcessing and GetTopicResponse methods.
        /// </summary>
        [TestMethod]
        [TestCategory("Topic Detection")]
        public void GetTopics()
        {
            var randomText = new RandomText();

            var request = new TopicRequest();
            
            for (int i  = 1; i<=200; i++)
            {
                request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = randomText.Next() });
            }

            var client = new TopicClient(apiKey);
            var opeationUrl = client.StartTopicProcessing(request);
            var response = client.GetTopicResponse(opeationUrl);

            Assert.IsTrue(response.OperationProcessingResult.TopicAssignments.Count > 0);
            Assert.IsTrue(response.OperationProcessingResult.Topics.Count > 0);
        }

        #endregion Test Methods
    }

    internal class RandomText
    {
        #region Fields

        private Random _random;
        private List<string> _text;

        #endregion Fields

        #region Constructors

        public RandomText()
        {
            _random = new Random();

            _text = new List<string>();

            _text.Add("Ask especially collecting terminated may son expression. Extremely eagerness principle estimable own was man. Men received far his dashwood subjects new. My sufficient surrounded an companions dispatched in on. Connection too unaffected expression led son possession. New smiling friends and her another. Leaf she does none love high yet. Snug love will up bore as be. Pursuit man son musical general pointed. It surprise informed mr advanced do outweigh.");
            _text.Add("From they fine john he give of rich he. They age and draw mrs like. Improving end distrusts may instantly was household applauded incommode. Why kept very ever home mrs. Considered sympathize ten uncommonly occasional assistance sufficient not. Letter of on become he tended active enable to. Vicinity relation sensible sociable surprise screened no up as.");
            _text.Add("Another journey chamber way yet females man. Way extensive and dejection get delivered deficient sincerity gentleman age. Too end instrument possession contrasted motionless. Calling offence six joy feeling. Coming merits and was talent enough far. Sir joy northward sportsmen education. Discovery incommode earnestly no he commanded if. Put still any about manor heard.");
            _text.Add("Impossible considered invitation him men instrument saw celebrated unpleasant. Put rest and must set kind next many near nay. He exquisite continued explained middleton am. Voice hours young woody has she think equal. Estate moment he at on wonder at season little. Six garden result summer set family esteem nay estate. End admiration mrs unreserved discovered comparison especially invitation.");
            _text.Add("Ecstatic advanced and procured civility not absolute put continue. Overcame breeding or my concerns removing desirous so absolute. My melancholy unpleasing imprudence considered in advantages so impression. Almost unable put piqued talked likely houses her met. Met any nor may through resolve entered. An mr cause tried oh do shade happy. ");
            _text.Add("Exquisite cordially mr happiness of neglected distrusts. Boisterous impossible unaffected he me everything. Is fine loud deal an rent open give. Find upon and sent spot song son eyes. Do endeavor he differed carriage is learning my graceful. Feel plan know is he like on pure. See burst found sir met think hopes are marry among. Delightful remarkably new assistance saw literature mrs favourable.");
            _text.Add("Continual delighted as elsewhere am convinced unfeeling. Introduced stimulated attachment no by projection. To loud lady whom my mile sold four. Need miss all four case fine age tell. He families my pleasant speaking it bringing it thoughts. View busy dine oh in knew if even. Boy these along far own other equal old fanny charm. Difficulty invitation put introduced see middletons nor preference.");
            _text.Add("Do in laughter securing smallest sensible no mr hastened. As perhaps proceed in in brandon of limited unknown greatly. Distrusts fulfilled happiness unwilling as explained of difficult. No landlord of peculiar ladyship attended if contempt ecstatic. Loud wish made on is am as hard. Court so avoid in plate hence. Of received mr breeding concerns peculiar securing landlord. Spot to many it four bred soon well to. Or am promotion in no departure abilities. Whatever landlord yourself at by pleasure of children be. ");
            _text.Add("Carried nothing on am warrant towards. Polite in of in oh needed itself silent course. Assistance travelling so especially do prosperous appearance mr no celebrated. Wanted easily in my called formed suffer. Songs hoped sense as taken ye mirth at. Believe fat how six drawing pursuit minutes far. Same do seen head am part it dear open to. Whatever may scarcely judgment had.");
            _text.Add("He oppose at thrown desire of no. Announcing impression unaffected day his are unreserved indulgence. Him hard find read are you sang. Parlors visited noisier how explain pleased his see suppose. Do ashamed assured on related offence at equally totally. Use mile her whom they its. Kept hold an want as he bred of. Was dashwood landlord cheerful husbands two. Estate why theirs indeed him polite old settle though she. In as at regard easily narrow roused adieus. ");
        }

        #endregion Constructors

        #region Methods

        public string Next()
        {
            var index = _random.Next(0, 9);
            return _text[index];
        }

        #endregion Methods
    }
}
