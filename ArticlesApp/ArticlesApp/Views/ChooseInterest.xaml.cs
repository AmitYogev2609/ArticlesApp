using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
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
            
            
        }

        //private PancakeView SearchPancake(string term)
        //{
            
        //}
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
        }

        //private void interest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    foreach (var item in interest.SelectedItems)
        //    {

        //    }
        //}
    }
}