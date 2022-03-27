using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowArticle : ContentPage
    {
        private CollectionView cov;
        public ShowArticle(ArticleWithPicture article,CollectionView cv)
        {
            this.BindingContext= new ShowArticleViewModel(article.Article);
            InitializeComponent();
            ti.Text = article.Article.ArticleName;
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();
            double width = App.Current.MainPage.Width;
            string htmlText = article.Article.HtmlText;
            if (!htmlText.Contains("html"))
            {

                htmlText = htmlText.Replace("width=\"auto\"", $"width =\"{width - 50}\"");
                hmlsource.Html = "<html>\n<head>\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />\n</head>\n<body>\n";
                hmlsource.Html += htmlText;
                hmlsource.Html += "\n</body>\n</html>";
            }
            else
            {
                //htmlText = htmlText.Replace("<html>", $"<html width =\"100%\">");
                //htmlText = htmlText.Replace("<body>", $"<body width =\"100%\">");
                htmlText = htmlText.Replace("<head>", "<head>\n<meta name=\"viewport\" content=\"width=device-width, initial-scale =1\">");
                hmlsource.Html = htmlText;
            }
            webview.Source = hmlsource;
            cov = cv;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            
        }
    }
}