﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PancakeView;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseInterest : ContentPage
    {
        public ChooseInterest(SignInViewModel context)
        {
            this.BindingContext = context;
            InitializeComponent();
            
            interest.ItemsSource = context.Interests;
            interest.IsEnabled = false;
        }

        
        private void interest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (InterestWithColor item in interest.ItemsSource)
            {
                item.BackgroundColor = Color.White;
            }
            foreach(InterestWithColor item in interest.SelectedItems)
            {
                item.BackgroundColor = Color.FromHex("#2EEB4C");
            }
            if(interest.SelectedItems.Count>=3)
            {
                interest.IsEnabled = true;
            }
            else interest.IsEnabled = false;
        }

        private void MoveToSignUp(object sender, EventArgs e)
        {
            SignInViewModel context= (SignInViewModel)this.BindingContext;
            List<Interest> MyInterests = new List<Interest>();
            foreach (InterestWithColor item in interest.SelectedItems)
            {
                MyInterests.Add(item.GetInterest());
            }
            context.MoveToSignUp(MyInterests);
        }

        
    }
}