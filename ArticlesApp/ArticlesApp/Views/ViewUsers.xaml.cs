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
    public partial class ViewUsers : ContentPage
    {
        Action acs;
        public ViewUsers(List<User> users, string title, Action ac=null)
        {
            ViewUsersViewModel context = new ViewUsersViewModel(users);
            this.BindingContext = context;
            InitializeComponent();
            acs = ac;
            ti.Text = title;
        }
        protected override void OnAppearing()
        {
            ViewUsersViewModel context=(ViewUsersViewModel)this.BindingContext;
            List<User> users = new List<User>();
            foreach (var item in context.Users)
            {
                users.Add(item.User);
            }
            context.Users.Clear();
            foreach (var item in users)
            {
                context.Users.Add(new UserViewModel(item));
            }
            base.OnAppearing();
        }
        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(colview.SelectedItem != null)
            {
                UserViewModel userViewModel = (UserViewModel)colview.SelectedItem;

                Page page = new ProfilePage(userViewModel.User.UserId);
                if (acs != null)
                {
                    page = new ProfilePage(userViewModel.User.UserId,acs);
                }

                Navigation.PushAsync(page);
                colview.SelectedItem=null;
            }
        }
        protected override void OnDisappearing()
        {
            if (acs != null)
                acs?.Invoke();
            base.OnDisappearing();
        }
    }
}