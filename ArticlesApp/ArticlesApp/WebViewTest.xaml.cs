using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewTest : ContentPage
    {
        public WebViewTest(string htmlText)
        {
            InitializeComponent();
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();

            hmlsource.Html = "<html>\n<body>\n";
            hmlsource.Html += htmlText;
            hmlsource.Html += "\n</body>\n</html>";
            webview.Source = hmlsource;
        }
    }
}