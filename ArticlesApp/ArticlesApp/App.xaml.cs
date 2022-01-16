using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Views;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

            InitializeComponent();
            Login = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
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
