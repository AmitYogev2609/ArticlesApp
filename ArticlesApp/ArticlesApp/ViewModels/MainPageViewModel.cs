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
namespace ArticlesApp.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Article> Articles;
        public Color diviedColor { get=>new Color(196, 196, 196, 0.29);  }
        public Action<Popup> NavigateToPopup;
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
                Articles = new ObservableCollection<Article>(articles.OrderByDescending(a => a.ArticleId));
            }
            else
                Articles = new ObservableCollection<Article>();
            
        }
        public async void readData()
        {

            //****

            
        }
    }
}
