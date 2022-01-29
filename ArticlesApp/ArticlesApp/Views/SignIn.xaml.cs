using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignIn : ContentPage
    {
        public SignIn()
        {
            SignInViewModel context = new SignInViewModel();
            this.BindingContext = context;
            ((SignInViewModel)this.BindingContext).NavigateToPageEvent += NavigateToAsync;
            InitializeComponent();
           
        }

        public async void NavigateToAsync()
        {
            Page p = new AddImage((SignInViewModel)this.BindingContext);
            await Navigation.PushAsync(p);
        }
        private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            ((SignInViewModel)this.BindingContext).ValidateEmail();
        }

        private void UserName_Unfocused(object sender, FocusEventArgs e)
        {
            ((SignInViewModel)this.BindingContext).ValdateUserName();
        }

        private void FullName_Unfocused(object sender, FocusEventArgs e)
        {
            ((SignInViewModel)this.BindingContext).ValdateFullName();
        }

        private void BirthDatePicker_Unfocused(object sender, FocusEventArgs e)
        {
            ((SignInViewModel)this.BindingContext).ValdateBirthdate();
        }
    }
}