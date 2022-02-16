using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Views;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.Collections.Generic;
using System.Threading;
using ArticlesApp.Services;
namespace ArticlesApp
{
    public partial class App : Application
    {
        public Page Login { get; set; }
        public List<Interest> Interests { get; set; }
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
            Interests = new List<Interest>();
            InitializeComponent();
           MainPage= new loadingStartPage();
           
        }

        protected override async void OnStart()
        {
            try
            {
                List<Interest> list = new List<Interest>();
                ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
                list = await proxy.GetInterests();
                ((App)App.Current).Interests = list;
                Login = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
                //Login = new Page1();
                MainPage = Login;
            }
            catch (Exception ex)
            {
                Application.Current.Quit();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
