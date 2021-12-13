﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Views;
namespace ArticlesApp
{
    public partial class App : Application
    {
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LogInPage()) { BarBackgroundColor = Color.White };
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
