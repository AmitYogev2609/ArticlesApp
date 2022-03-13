using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PancakeView;
using Xamarin.CommunityToolkit.Extensions;


namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseInterest : ContentPage
    {
        public ChooseInterest(SignInViewModel context)
        {
            this.BindingContext = context;
            InitializeComponent();
            context.NavigateToLoading += NavigteToLoading;
            interest.ItemsSource = context.Interests;
            finish.IsEnabled = false;
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
            if(interest.SelectedItems!=null)
            { 
            if(interest.SelectedItems.Count>=3)
            {
                finish.IsEnabled = true;
            }
            else finish.IsEnabled = false;
            }
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
        private  void NavigteToLoading( LoadingPopUp page)
        {
             Navigation.ShowPopup(page);
        }
        
    }
}