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
        public List<Article> Articles { get; set; }
        public List<User> Users { get; set; }
        public List<Interest> Interests { get; set; }
        public User User { get; set; }
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
            Users=new List<User>();
            Articles=new List<Article>();
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
                ((App)App.Current).Users = await proxy.GetUsers();
                ((App)App.Current).Articles = await proxy.GetAllArticles();
                //Login = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
                ////Login = new Page1();
                // MainPage = Login;
                //                MainPage = new NavigationPage(new Page1());
                MainPage = new NavigationPage(new TabbedMenu("amity2609@gmail.com", "1234")) { BarBackgroundColor = Color.White };
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
