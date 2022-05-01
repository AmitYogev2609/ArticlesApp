using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestHtml : ContentPage
    {
        string htmlText;
        public TestHtml(Article article)
        {
            InitializeComponent();
            html.Text = "<style>\n</style>";
            htmlText = article.HtmlText;
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();
            hmlsource.Html = htmlText;
            webview.Source = hmlsource;
        }

        private void btn_Clicked(object sender, EventArgs e)
        {
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();
            string newHtml = htmlText;
            newHtml = newHtml.Replace("width=\"816\"", "width=\"100%\"");
            newHtml = newHtml.Replace("height=\"1056\"", "height=\"100%\"");
            newHtml = newHtml.Replace("<head>", "<head>" + html.Text);
            newHtml = newHtml.Replace("<head>", "<head>\n<meta name=\"viewport\" content=\"width=device-width, initial-scale =1\">");
            
            hmlsource.Html = newHtml;
            webview.Source = hmlsource;
        }
    }
}