using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using ArticlesApp.ViewModels;
using ArticlesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Fonts;
using System.Collections.ObjectModel;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowArticle : ContentPage
    {
        public CollectionView collectionView;
        
        public ShowArticle(ArticleWithPicture article)
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
                htmlText = ConvertHtml(htmlText);
                hmlsource.Html = htmlText;
            }
            webview.Source = hmlsource;
           
            double height = App.Current.MainPage.Height;
            
            grd.WidthRequest = width;
            gtd1.WidthRequest = width;
            webview.WidthRequest = width;
            User logedUser = ((App)App.Current).User;
            foreach(var obj in logedUser.FavoriteArticles )
            {
                if(obj.ArticleId==article.Article.ArticleId)
                {
                    star.Text = FontIconClass.Star;
                    star.TextColor = Color.Gold;
                }
            }
        }
        public ShowArticle(ArticleWithPicture article,CollectionView collectionView)
        {
            this.BindingContext = new ShowArticleViewModel(article.Article);
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
                htmlText = ConvertHtml(htmlText);
                hmlsource.Html = htmlText;
            }
            webview.Source = hmlsource;

            double height = App.Current.MainPage.Height;

            grd.WidthRequest = width;
            gtd1.WidthRequest = width;
            webview.WidthRequest = width;
            User logedUser = ((App)App.Current).User;
            foreach (var obj in logedUser.FavoriteArticles)
            {
                if (obj.ArticleId == article.Article.ArticleId)
                {
                    star.Text = FontIconClass.Star;
                    star.TextColor = Color.Gold;
                }
            }
            this.collectionView = collectionView;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            
            
        }
        public static string ConvertHtml(string html)
        {
            //Manipulate html
            int widthStartIndex = html.IndexOf("width=\"");
            int heightStartIndex = html.IndexOf("height=\"");
            int widthEndIndex = html.IndexOf("\"", widthStartIndex + 7);
            int heightEndIndex = html.IndexOf("\"", heightStartIndex + 8);
            string width = html.Substring(widthStartIndex + 7, widthEndIndex - widthStartIndex - 7);
            string height = html.Substring(heightStartIndex + 8, heightEndIndex - heightStartIndex - 8);
            int continueIndex = html.IndexOf(">", heightEndIndex);

            string newHtml = html.Substring(0, widthStartIndex - 1);
            newHtml += $" width=\"100%\" height=\"{height}\" viewBox=\"0 0 {width} {height}\" preserveaspectration=\"xMidYMid meet\"";
            newHtml += html.Substring(continueIndex);
            return newHtml;
        }
        protected async override void OnAppearing()
        {
            ShowArticleViewModel context = (ShowArticleViewModel)this.BindingContext;
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            List<ArticleInterestType> InterestTypes = await proxy.GetArticleIntersetType(context.Article.ArticleId);
            context.Article.ArticleInterestTypes=InterestTypes;
            List<AuthorsArticle> authorsArticles = await proxy.GetAuthorsArticle(context.Article.ArticleId);
            context.Article.AuthorsArticles = authorsArticles;
            base.OnAppearing();
        }



        private void star_Clicked(object sender, EventArgs e)
        {
            ShowArticleViewModel context = (ShowArticleViewModel)this.BindingContext;
            if (star.Text!= FontIconClass.Star)
            { 
                star.Text = FontIconClass.Star;
                star.TextColor= Color.Gold;
                context.uptadeFavoriteArticle();
            }
            else
            {
                star.Text = FontIconClass.StarOutline;
                star.TextColor = Color.Black;
                context.RemoveFavoriteArticle();
                if(collectionView!=null)
                { 
                    ObservableCollection<ArticleWithPicture> articles=(ObservableCollection <ArticleWithPicture>) collectionView.ItemsSource;
                    ArticleWithPicture articleWithPicture = articles.Where(arti => arti.Article.ArticleId == context.Article.ArticleId).FirstOrDefault();
                    articles.Remove(articleWithPicture);
                }
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            ShowArticleViewModel context=(ShowArticleViewModel)this.BindingContext;
            Page page = new CommentPage(context.Article);
            Navigation.PushAsync(page);
        }

        private void Authors_Tapped(object sender, EventArgs e)
        {
            ShowArticleViewModel context = (ShowArticleViewModel)this.BindingContext;
            List<User> usres = new List<User>();
            foreach (var item in context.Article.AuthorsArticles)
            {
                usres.Add(item.User);
            }
            Page page = new ViewUsers(usres, $"\"{context.Article.ArticleName}\" authors");
            Navigation.PushAsync(page);

        }
        private void Interests_Tapped(object sender, EventArgs e)
        {
            ShowArticleViewModel context = (ShowArticleViewModel)this.BindingContext;
            List<Interest> interests = new List<Interest>();
            foreach (var item in context.Article.ArticleInterestTypes)
            {
                Interest in1 = ((App)App.Current).Interests.Where(intr => intr.InterestId == item.InterestId).FirstOrDefault();
                interests.Add(in1);
            }
            Page page = new ViewInterests(interests, ((App)App.Current).User, $"\"{context.Article.ArticleName}\" intrests", false);
            Navigation.PushAsync(page);
        }
    }
}