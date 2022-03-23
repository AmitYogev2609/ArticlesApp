﻿using System;
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
        public string date { get=>Article.PublishDate.ToShortDateString();  }
        public string athours { get; set; }
        public ArticleWithPicture(Article article)
        {
            ArticlesAPIProxy proxy= ArticlesAPIProxy.CreateProxy();
            string uri = $"{proxy.GetBasePhotoUri()}ArticleImage/{article.ArticleId}.png";
            Article= article;
            athours = getAthours(article);
        }
        private string getAthours(Article article)
        {
            string str= "by:";
            foreach (var item in Article.AuthorsArticles)
            {
                str += $" {item.User.UserName},";
            }
            return str;
        }
    }
    public class MainPageViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ObservableCollection<ArticleWithPicture> Articles;
        public Color diviedColor { get=>new Color(196, 196, 196, 0.29);  }
        public Action<Popup> NavigateToPopup;
        public Action NavigateToPageEvent;
       
        public MainPageViewModel()
        {
            List<Article> articles = new List<Article>();
            if (((App)App.Current).User != null)
            {
                foreach (Followeduser followedUser in ((App)App.Current).User.FolloweduserFollowings)
                    foreach (AuthorsArticle author in followedUser.User.AuthorsArticles)
                    {
                        if (!articles.Contains(author.Article))
                            articles.Add(author.Article);
                    }

                foreach (FollwedInterest followedInterest in ((App)App.Current).User.FollwedInterests)
                    foreach (ArticleInterestType type in followedInterest.Interest.ArticleInterestTypes)
                    {
                        if (!articles.Contains(type.Article))
                            articles.Add(type.Article);
                    }
                List<ArticleWithPicture> list = new List<ArticleWithPicture>();
                foreach (var article in articles)
                {
                    list.Add(new ArticleWithPicture(article));
                }
                
                Articles = new ObservableCollection<ArticleWithPicture>(list.OrderByDescending(a => a.Article.ArticleId));
            }
            else
                Articles = new ObservableCollection<ArticleWithPicture>();
            
        }
      
        public async void ReadData()
        {

            //****

            
        }
    }
}
