using System;
using System.Collections.Generic;
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
using Microsoft.ProjectOxford.Text.KeyPhrase;

namespace Microsoft.ProjectOxford.Text.Controls
{
    /// <summary>
    /// Interaction logic for KeyPhraseDetectionPage.xaml
    /// </summary>
    public partial class KeyPhraseDetectionPage : Page, INotifyPropertyChanged
    {
        #region Fields

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(SentimentAnalysisPage));

        private string _keyPhrases;
        private string _inputText;

        #endregion Fields

        #region Constructors

        public KeyPhraseDetectionPage()
        {
            InitializeComponent();
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

        public string KeyPhrases
        {
            get
            {
                return _keyPhrases;
            }
            set
            {
                if (_keyPhrases != value)
                {
                    _keyPhrases = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("KeyPhrases"));
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

        #endregion Properties

        #region Methods

        private async void Detect_Key_Phrases(object sender, RoutedEventArgs e)
        {
            this.KeyPhrases = "";

            try
            {
                var language = await GetLanguage();
                var document = new KeyPhraseDocument() { Id = Guid.NewGuid().ToString(), Text = this.InputText, Language = language };

                var request = new KeyPhraseRequest();
                request.Documents.Add(document);

                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                var client = new KeyPhraseClient(mainWindow._scenariosControl.SubscriptionKey);

                MainWindow.Log("Request: Identifying key phrases..");
                var response = await client.GetKeyPhrasesAsync(request);
                MainWindow.Log("Response: Success. Key phrases identified.");

                var keyPhrases = new StringBuilder();

                foreach (var keyPhrase in response.Documents[0].KeyPhrases)
                {
                    keyPhrases.Append(string.Format("{0} ", keyPhrase));
                }

                this.KeyPhrases = keyPhrases.ToString();
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

        #endregion
    }
}
