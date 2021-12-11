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
    public partial class ForgotPasswordEnterEmail : ContentPage
    {
        public ForgotPasswordEnterEmail()
        {
            InitializeComponent();
        }
        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((ForgotPassWordViewModel)this.BindingContext).NavigateToPageEvent += NavigateToAsync;
        }
    }
}