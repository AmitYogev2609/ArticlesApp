using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Services;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            //ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            //Task<List<Interest>> taskinterests = proxy.GetInitialInterests();
            //List<Interest> interests = taskinterests.Result;
            InitializeComponent();
            //test.ItemsSource = interests;
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            string htmltext = texteditor.HtmlText;
            Navigation.PushAsync(new WebViewTest(htmltext));
        }
    }
}