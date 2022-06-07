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
    public class ArticleWithPicture : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Article Article { get; set; }
        public string PhotoUrl { get; set; }
        public string date { get => Article.PublishDate.ToShortDateString(); }
        private string Athours;
        public string athours { get=>Athours; set
            {
                if(value!=Athours)
                {
                    Athours=value;
                    OnPropertyChanged(nameof(athours));
                }
            } }
       
        public ArticleWithPicture(Article article,User user)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            PhotoUrl = $"{proxy.GetBasePhotoUri()}ArticleImage/{article.ArticleId}.jpg";
            Article = article;
            getAthours(Article.ArticleId);
            this.Athours = Article.AuthorsList;
        }
        private async void getAthours(int articleId)
        {
            //ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            //athours = await proxy.GetArticleAuthors(articleId);
        }
    }
}
