using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ArticlesApp.Views;
using ArticlesApp.Services;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;
namespace ArticlesApp.ViewModels
{
    public class ArticleWithPicture
    {
        public Article Article { get; set; }
        public string PhotoUrl { get; set; }
        public string date { get => Article.PublishDate.ToShortDateString(); }
        public string athours { get; set; }
       
        public ArticleWithPicture(Article article)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            PhotoUrl = $"{proxy.GetBasePhotoUri()}ArticleImage/{article.ArticleId}.jpg";
            Article = article;
            athours = getAthours(article);
        }
        private string getAthours(Article article)
        {
            string str = "by:";
            foreach (var item in Article.AuthorsArticles)
            {
                str += $" {item.User.UserName},";
            }
            return str;
        }
    }
}
