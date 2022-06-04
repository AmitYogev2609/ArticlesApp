using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Views;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.Collections.Generic;
using System.Threading;
using ArticlesApp.Services;
using System.Linq;

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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjUwNDc2QDMyMzAyZTMxMmUzMGY4T3Vab1N2SVdSditUV3hxNEtUSGNGaGx1aWlyRHdUaSszZW1IQmttNkk9");
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
                List<Article> articles = await proxy.GetAllArticles();
                List<User> users = await proxy.GetUsers();
                //((App)App.Current).Articles=articles;
                //((App)App.Current).Users=users;
                try
                {
                    foreach (Interest interest in list)
                        foreach (ArticleInterestType type in interest.ArticleInterestTypes)
                        {
                            if (!((App)App.Current).Articles.Contains(type.Article))
                                ((App)App.Current).Articles.Add(type.Article);

                        }
                    ((App)App.Current).Users = users;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Login = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
                //Login = new Page1();
                MainPage = Login;
                // MainPage = new NavigationPage(new Page1());
                //MainPage = new NavigationPage(new TabbedMenu("amity2609@gmail.com", "1234")) { BarBackgroundColor = Color.White,BarTextColor=Color.Black };

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
