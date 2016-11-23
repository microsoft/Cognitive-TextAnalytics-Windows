using Microsoft.ProjectOxford.Text.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.ProjectOxford.Text.Core;
using Microsoft.ProjectOxford.Text.Language;
using Microsoft.ProjectOxford.Text.Sentiment;

namespace Microsoft.ProjectOxford.Text.Controls
{
    /// <summary>
    /// Interaction logic for SentimentAnalysisPage.xaml
    /// </summary>
    public partial class SentimentAnalysisPage : Page, INotifyPropertyChanged
    {
        #region Fields

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(SentimentAnalysisPage));

        private ObservableCollection<SamplePhrase> _samplePhrases = new ObservableCollection<SamplePhrase>();
        private string _score;
        private string _inputText;

        #endregion Fields

        #region Constructors

        public SentimentAnalysisPage()
        {
            InitializeComponent();
            this.SamplePhrases = SamplePhrase.GetSamplePhrases();
        }

        #endregion Constructors

        #region Events

        /// <summary>
        /// Implements INotifyPropertyChanged interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Properties

        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }

            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        public string Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Score"));
                    }
                }
            }
        }

        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("InputText"));
                    }
                }
            }
        }

        public ObservableCollection<SamplePhrase> SamplePhrases
        {
            get
            {
                return _samplePhrases;
            }
            set
            {
                if (_samplePhrases != value)
                {
                    _samplePhrases = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("SamplePhrases"));
                    }
                }
            }
        }

        #endregion Properties

        #region Methods

        private async void Analyze_Text(object sender, RoutedEventArgs e)
        {
            this.Score = "";

            try
            {
                var language = await GetLanguage();
                var document = new SentimentDocument() { Id = Guid.NewGuid().ToString(), Text = this.InputText, Language = language };

                var request = new SentimentRequest();
                request.Documents.Add(document);

                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                var client = new SentimentClient(mainWindow._scenariosControl.SubscriptionKey);

                MainWindow.Log("Request: Analyzing sentiment.");
                var response = await client.GetSentimentAsync(request);
                MainWindow.Log("Response: Success. Sentiment analyzed.");

                var score = response.Documents[0].Score * 100;
                this.Score = string.Format("{0}%", score);
            }
            catch (Exception ex)
            {
                MainWindow.Log(ex.Message);
            }
        }

        private async Task<string> GetLanguage()
        {
            var document = new Document() { Id = Guid.NewGuid().ToString(), Text = this.InputText };

            var request = new LanguageRequest();
            request.Documents.Add(document);

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            var client = new LanguageClient(mainWindow._scenariosControl.SubscriptionKey);

            MainWindow.Log("Request: Identifying language.");
            var response = await client.GetLanguagesAsync(request);
            MainWindow.Log("Response: Success. Language identified.");

            return response.Documents[0].DetectedLanguages[0].Iso639Name;
        }

        #endregion Methods
    }
}
