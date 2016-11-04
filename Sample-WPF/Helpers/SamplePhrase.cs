using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.ProjectOxford.Text.Helpers
{
    public class SamplePhrase
    {
        #region Properties

        public string Language
        {
            get;
            set;
        }

        public Sentiment Sentiment
        {
            get;
            set;
        }

        public string Text
        {
            get;
            set;
        }

        #endregion Properties

        #region Methods

        public static ObservableCollection<SamplePhrase> GetSamplePhrases(Sentiment sentiment)
        {
            var allPhrases = GetSamplePhrases();

            var phrases = from p in allPhrases
                          where p.Sentiment == sentiment
                          select p;

            return new ObservableCollection<SamplePhrase>(phrases);
        }

        public static ObservableCollection<SamplePhrase> GetSamplePhrases()
        {
            var samplePhrases = new ObservableCollection<SamplePhrase>();

            samplePhrases.Add(new SamplePhrase() { Language = "English", Sentiment = Sentiment.Positive, Text = "I had a wonderful experience! The rooms were wonderful and the staff were helpful." });
            samplePhrases.Add(new SamplePhrase() { Language = "English", Sentiment = Sentiment.Negative, Text = "I had a terrible time at the hotel. The staff were rude and the food was awful." });
            samplePhrases.Add(new SamplePhrase() { Language = "Spanish", Sentiment = Sentiment.Positive, Text = "Los caminos que llevan hasta Monte Rainier son espectaculares y hermosos." });
            samplePhrases.Add(new SamplePhrase() { Language = "Spanish", Sentiment = Sentiment.Negative, Text = "La carretera estaba atascada. Había mucho tráfico el día de ayer." });

            return samplePhrases;
        }

        #endregion Methods
    }
}
