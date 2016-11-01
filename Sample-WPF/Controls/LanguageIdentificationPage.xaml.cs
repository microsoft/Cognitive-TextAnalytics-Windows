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

namespace Microsoft.ProjectOxford.Text.Controls
{
    /// <summary>
    /// Interaction logic for LanguageIdentificationPage.xaml
    /// </summary>
    public partial class LanguageIdentificationPage : Page
    {
        #region Constructors

        public LanguageIdentificationPage()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public string LanguageName { get; set; }
        public string Iso639LanguageName { get; set; }
        public string Confidence { get; set; }
        public string InputText { get; set; }

        #endregion Properties

        #region Methods

        private void Analyze_Text(object sender, RoutedEventArgs e)
        {

        }

        #endregion Methods
    }
}
