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
       

    }
}