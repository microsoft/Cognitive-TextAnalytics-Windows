using System;
using System.Collections.Generic;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Microsoft.ProjectOxford.Text.Controls
{
    /// <summary>
    /// Interaction logic for LanguageIdentificationPage.xaml
    /// </summary>
    public partial class LanguageIdentificationPage : Page, INotifyPropertyChanged
    {
        #region Fields

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(LanguageIdentificationPage));

        private string _languageName;
        private string _iso639LanguageName;
        private string _confidence;
        private string _inputText;

        #endregion Fields

        #region Constructors

        public LanguageIdentificationPage()
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

        public string LanguageName
        {
            get
            {
                return _languageName;
            }
            set
            {
                if (_languageName != value)
                {
                    _languageName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("LanguageName"));
                    }
                }
            }
        }

        public string Iso639LanguageName
        {
            get
            {
                return _iso639LanguageName;
            }
            set
            {
                if (_iso639LanguageName != value)
                {
                    _iso639LanguageName = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Iso639LanguageName"));
                    }
                }
            }
        }

        public string Confidence
        {
            get
            {
                return _confidence;
            }
            set
            {
                if (_confidence != value)
                {
                    _confidence = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Confidence"));
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

        private async void Analyze_Text(object sender, RoutedEventArgs e)
        {
            this.LanguageName = "";
            this.Iso639LanguageName = "";
            this.Confidence = "";

            try
            {
                var document = new Document() { Id = Guid.NewGuid().ToString(), Text = this.InputText };

                var request = new LanguageRequest();
                request.Documents.Add(document);

                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                var client = new LanguageClient(mainWindow._scenariosControl.SubscriptionKey);

                MainWindow.Log("Request: Identifying language.");
                var response = await client.GetLanguagesAsync(request);
                MainWindow.Log("Response: Success. Language identified.");

                this.LanguageName = response.Documents[0].DetectedLanguages[0].Name;
                this.Iso639LanguageName = response.Documents[0].DetectedLanguages[0].Iso639Name;

                var confidence = response.Documents[0].DetectedLanguages[0].Score * 100;
                this.Confidence = string.Format("{0}%", confidence);
            }
            catch (Exception ex)
            {
                MainWindow.Log(ex.Message);
            }
        }

        #endregion Methods
    }
}
