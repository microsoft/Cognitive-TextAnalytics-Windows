using Microsoft.ProjectOxford.Text.Helpers;
using Microsoft.ProjectOxford.Text.Topic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for TopicDetectionPage.xaml
    /// </summary>
    public partial class TopicDetectionPage : Page, INotifyPropertyChanged
    {
        #region Fields

        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(SentimentAnalysisPage));

        private string _topics;
        private string _inputText;

        #endregion Fields

        #region Constructors

        public TopicDetectionPage()
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

        public string Topics
        {
            get
            {
                return _topics;
            }
            set
            {
                if (_topics != value)
                {
                    _topics = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Topics"));
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

        private async void Detect_Topics(object sender, RoutedEventArgs e)
        {
            try
            {
                var source = this.InputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
                var randomText = new RandomText(source);

                var request = new TopicRequest();

                for (int i = 0; i<=100;i++)
                {
                    request.Documents.Add(new TopicDocument() { Id = i.ToString(), Text = randomText.Next() });
                }

                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                var client = new TopicClient(mainWindow._scenariosControl.SubscriptionKey);
                var opeationUrl = await client.StartTopicProcessingAsync(request);

                TopicResponse response = null;
                var doneProcessing = false;

                while(!doneProcessing)
                {
                    response = await client.GetTopicResponseAsync(opeationUrl);

                    switch(response.Status)
                    {
                        case TopicOperationStatus.Cancelled:
                            MainWindow.Log("Operation Status: Cancelled");
                            doneProcessing = true;
                            break;
                        case TopicOperationStatus.Failed:
                            MainWindow.Log("Operation Status: Failed");
                            doneProcessing = true;
                            break;
                        case TopicOperationStatus.NotStarted:
                            MainWindow.Log("Operation Status: Not Started");
                            Thread.Sleep(60000);
                            break;
                        case TopicOperationStatus.Running:
                            MainWindow.Log("Operation Status: Running");
                            Thread.Sleep(60000);
                            break;
                        case TopicOperationStatus.Succeeded:
                            MainWindow.Log("Operation Status: Succeeded");
                            doneProcessing = true;
                            break;
                    }
                }

                foreach(var topic in response.OperationProcessingResult.Topics)
                {
                    var score = topic.Score * 100;
                    MainWindow.Log(string.Format("{0} ({1}%)", topic.KeyPhrase, score));
                }
            }
            catch (Exception ex)
            {
                MainWindow.Log(ex.Message);
            }
        }

        #endregion Methods
    }
}
