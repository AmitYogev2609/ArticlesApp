using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProfilePage : ContentView
    {
        public MyProfilePage()
        {
            User user = ((App)App.Current).User;
            MyProfileViewModel context = new MyProfileViewModel(user);
            this.BindingContext = context ;
            InitializeComponent();
            UserWithPicture userWP = context.User;
            mangeIcon.IsVisible = userWP.User.IsManger;
            colview.ItemsSource = context.articles;
        }

        private void logOut(object sender, EventArgs e)
        {
            ((App)App.Current).User = null;
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
    }
}