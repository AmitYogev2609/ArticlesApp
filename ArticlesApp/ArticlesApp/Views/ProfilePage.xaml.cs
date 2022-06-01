using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using ArticlesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
       
        public  ProfilePage(int userid)
        {
            
            ProfilePageViewModel context = new ProfilePageViewModel(userid);
            this.BindingContext = context;
            InitializeComponent();
         
        }

        protected override async void OnAppearing()
        {
            ProfilePageViewModel context = (ProfilePageViewModel)this.BindingContext;
            int userid = context.userid;
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            User user = await proxy.GetUserDetails(userid);
            context.User = new UserWithPicture(user);
            foreach (var item in context.User.User.FollwedInterests)
            {
                context.userIntrest.Add(item);
            }
            foreach (var item in context.User.User.FolloweduserFollowings)
            {
                context.followedUsers.Add(item);
            }
            foreach (var item in context.User.User.FolloweduserUsers)
            {
                context.follwedBy.Add(item);
            }
            foreach (var item in context.User.User.AuthorsArticles)
            {
                context.articles.Add(new ArticleWithPicture(item.Article,item.User));
            }
            UserWithPicture userWP = context.User;
            colview.ItemsSource = context.articles;
            base.OnAppearing();
        }

        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArticleWithPicture articleWithPicture = (ArticleWithPicture)colview.SelectedItem;
            if (articleWithPicture != null)
            {
                Page page = new ShowArticle(articleWithPicture, colview);
                colview.SelectedItem = null;
                Navigation.PushAsync(page);
            }
        }
    }
}
