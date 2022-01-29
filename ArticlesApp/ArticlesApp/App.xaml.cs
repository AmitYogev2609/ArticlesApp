using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Views;
using ArticlesApp.ViewModels;
namespace ArticlesApp
{
    public partial class App : Application
    {
        public Page Login { get; set; }
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTY1Nzk3QDMxMzkyZTM0MmUzMGdKZ1JlTzM1elE3T2RpZXVwSHRuOC8xd09uc3prSGptOC9jdXU2WTQ0QXc9");

            InitializeComponent();
            //Login = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
            Login = new Page1();
            MainPage = Login; 
           
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
