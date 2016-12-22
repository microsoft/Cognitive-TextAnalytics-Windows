using Microsoft.ProjectOxford.Text.Controls;
using SampleUserControlLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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

namespace Microsoft.ProjectOxford.Text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            ServicePointManager.DefaultConnectionLimit = 1000;

            this.ViewModel = new MainViewModel()
            {
                LanguageIdentificationDescription = "Identify the language text is written in.",
                SentimentAnalysisDescription = "Identity the sentiment in text.",
                KeyPhraseDetectionDescription = "Detect the key phrases in text."
            };

            this.DataContext = this.ViewModel;

            this._scenariosControl.SampleScenarioList = new Scenario[]
            {
                new Scenario()
                {
                    PageClass = typeof(LanguageIdentificationPage),
                    Title = "Language Identification"
                },
                new Scenario()
                {
                    PageClass = typeof(SentimentAnalysisPage),
                    Title = "Sentiment Analysis"
                },
                new Scenario()
                {
                    PageClass = typeof(KeyPhraseDetectionPage),
                    Title = "Key Phrase Detection"
                }
            };
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets view model instance for MainWindow
        /// </summary>
        public MainViewModel ViewModel
        {
            get; private set;
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Log message in main window log pane
        /// </summary>
        /// <param name="format">format string</param>
        /// <param name="args">format arguments</param>
        public static void Log(string format, params object[] args)
        {
            ((MainWindow)Application.Current.MainWindow)._scenariosControl.Log(string.Format(format, args));
        }

        #endregion Methods

        #region Nested Types

        public class MainViewModel : INotifyPropertyChanged
        {
            #region Events

            /// <summary>
            /// Implements INotifyPropertyChanged interface
            /// </summary>
            public event PropertyChangedEventHandler PropertyChanged;

            #endregion Events

            #region Properties

            public string LanguageIdentificationDescription
            {
                get;
                set;
            }

            public string SentimentAnalysisDescription
            {
                get;
                set;
            }

            public string KeyPhraseDetectionDescription
            {
                get;
                set;
            }

            #endregion Properties

            #region Methods

            /// <summary>
            /// Helper function for INotifyPropertyChanged interface 
            /// </summary>
            /// <typeparam name="T">Property type</typeparam>
            /// <param name="caller">Property name</param>
            private void OnPropertyChanged<T>([CallerMemberName]string caller = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(caller));
                }
            }

            #endregion Methods
        }

        #endregion Nested Types
    }
}
