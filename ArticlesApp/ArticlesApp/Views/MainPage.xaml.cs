using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.CommunityToolkit.Extensions;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentView
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel context = new MainPageViewModel();
            this.BindingContext = context;
            context.NavigateToPopup += NavigteToLoading;
            List<string> list = new List<string>();
            list.Add("amit");
            arti.ItemsSource = list;
            //context.readData();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Page page =  new AddArticleDetail();
            Navigation.PushAsync(page);
        }
        private void NavigteToLoading(Popup page)
        {
            Navigation.ShowPopup(page);
        }

    }
}