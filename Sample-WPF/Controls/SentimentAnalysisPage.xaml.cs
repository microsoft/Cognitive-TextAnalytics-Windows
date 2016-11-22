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

namespace Microsoft.ProjectOxford.Text.Controls
{
    /// <summary>
    /// Interaction logic for SentimentAnalysisPage.xaml
    /// </summary>
    public partial class SentimentAnalysisPage : Page, INotifyPropertyChanged
    {
        #region Fields

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(LanguageIdentificationPage));

        private ObservableCollection<SamplePhrase> _samplePhrases = new ObservableCollection<SamplePhrase>();
        private string _score;
        private string _inputText;

        #endregion Fields

        #region Constructors

        public SentimentAnalysisPage()
        {
            InitializeComponent();
            this.SamplePhrases = SamplePhrase.GetSamplePhrases(Sentiment.Positive);
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

        #endregion Methods
    }
}
