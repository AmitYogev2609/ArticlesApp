using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Services;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentView
    {
        public Action refeshAc;
        public MyProfilePage()
        {
            User user = ((App)App.Current).User;
            MyProfileViewModel context = new MyProfileViewModel(user);
            this.BindingContext = context ;
            refeshAc += context.refresh;
            context.navigateTopage += NavigateToAsync;
            context.ac = this.refeshAc;
            InitializeComponent();
            UserWithPicture userWP = context.User;
            mangeIcon.IsVisible = userWP.User.IsManger;
            colview.ItemsSource = context.articles;
        }
        
        private async void logOut(object sender, EventArgs e)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            ((App)App.Current).User = null;
            ((App)App.Current).Interests.Clear();
           ((App)App.Current).Articles.Clear();
            ((App)App.Current).Users.Clear();
            ((App)App.Current).Interests = await proxy.GetInterests();
            List<User> users = await proxy.GetUsers();
           
            try
            {
                foreach (Interest interest in ((App)App.Current).Interests)
                    foreach (ArticleInterestType type in interest.ArticleInterestTypes)
                    {
                        if (!((App)App.Current).Articles.Contains(type.Article))
                            ((App)App.Current).Articles.Add(type.Article);

                    }
                ((App)App.Current).Users = users;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
            ((App)App.Current).MainPage  = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };

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

        private void EditProfileButton_Clicked(object sender, EventArgs e)
        {
            Page page = new EditProfile(ProfilePictureImage.Source,refeshAc);
            Navigation.PushAsync(page);
        }
        public async void NavigateToAsync(Page p)
        {
          
            await Navigation.PushAsync(p);
        }

        private void ToAdminPage(object sender, EventArgs e)
        {
            Page page = new AdminPage();
            Navigation.PushAsync(page);
        }
    }
}