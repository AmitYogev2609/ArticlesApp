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
    public partial class LogInPage : ContentPage
    {
        public LogInPage()
        {
            InitializeComponent();
            LogInViewModel context = new LogInViewModel();
            context.NavigateToPageEvent += NavigateToAsync;
            this.BindingContext = context;
        }
        public async void NavigateToAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
        
    }
}