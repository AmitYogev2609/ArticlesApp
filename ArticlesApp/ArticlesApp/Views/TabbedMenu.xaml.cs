using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using ArticlesApp.Services;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedMenu : ContentPage
    {
        public TabbedMenu(string email, string password)
        {
            InitializeComponent();
            

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
          
        }

        private void TabViewItem_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
           FavoriteArticleViewModel context=(FavoriteArticleViewModel) FavoriteArticleTab.CurrentContent.BindingContext;
            context.Articles.Clear();
            User user = ((App)App.Current).User;
            foreach (var item in user.FavoriteArticles)
            {
                context.Articles.Add(new ArticleWithPicture(item.Article,((App)App.Current).User));
            }
        }

       

       

        private void MyprofileTab_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
            MyProfileViewModel context = (MyProfileViewModel)MyprofileTab.CurrentContent.BindingContext;

            User user = ((App)App.Current).User;
            context.User=new UserWithPicture(user);
            context.articles.Clear();
            //context.userIntrest = new ObservableCollection<FollwedInterest>(user.FollwedInterests);
            //context.followedUsers = new ObservableCollection<Followeduser>(user.FolloweduserFollowings);
            //context.follwedBy = new ObservableCollection<Followeduser>(user.FolloweduserUsers);
            foreach (var item in user.AuthorsArticles)
            {
                context.articles.Add(new ArticleWithPicture(item.Article,user));
            }
        }

        private void HomeTab_TabTapped(object sender, Xamarin.CommunityToolkit.UI.Views.TabTappedEventArgs e)
        {
           MainPageViewModel context = (MainPageViewModel)HomeTab.CurrentContent.BindingContext;
            List<Article> articles = new List<Article>();
            context.Articles.Clear();
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
                    list.Add(new ArticleWithPicture(article, ((App)App.Current).User));
                }
                List<ArticleWithPicture> sortedList = list.OrderByDescending(a => a.Article.ArticleId).ToList<ArticleWithPicture>();
                foreach(var article in sortedList)
                {
                    context.Articles.Add(article);
                }
            }
            else
                context.Articles = new ObservableCollection<ArticleWithPicture>();
        }
    }
}