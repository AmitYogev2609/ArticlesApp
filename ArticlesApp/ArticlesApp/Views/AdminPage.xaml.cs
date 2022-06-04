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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            AdminPageViewModel context= new AdminPageViewModel();
            this.BindingContext= context;
            InitializeComponent();
        }

        private void UserIdDeleteBt_Clicked(object sender, EventArgs e)
        {

        }

        private void InterestTodleteBt_Clicked(object sender, EventArgs e)
        {

        }
    }
}