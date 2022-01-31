using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseInterest : ContentPage
    {
        public ChooseInterest(SignInViewModel context)
        {
            this.BindingContext = context;
            InitializeComponent();
            list.ItemsSource = context.Interests;
            
        }
    }
}