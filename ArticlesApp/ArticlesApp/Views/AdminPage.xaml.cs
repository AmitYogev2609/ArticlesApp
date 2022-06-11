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
            context.uptade += upt;
            InitializeComponent();
            yum.Border.Color = Color.Black;
        }

        public void upt()
        {
            UserToMakeAsmin.Text = "";
        }

        private void UserTomakeAdmin_Clicked(object sender, EventArgs e)
        {
            AdminPageViewModel context = ( AdminPageViewModel)this.BindingContext;
            context.UserToMakeAdmin = int.Parse(UserToMakeAsmin.Text);
            context.makeUser();
            yum.Border.Color = Color.Green;
           
        }
    }
}