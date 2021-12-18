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
            InitializeComponent();
            SignInViewModel context = new SignInViewModel();
            this.BindingContext = context;
        }

        public void EmailEntry_Completed(object sender, EventArgs e)
        {
            ((SignInViewModel)this.BindingContext).ValidateEmail();
        }
    }
}