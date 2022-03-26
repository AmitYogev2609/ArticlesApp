using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentView
    {
        public SearchPage()
        {
            InitializeComponent();
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            test.Source = ImageSource.FromFile("http://10.0.2.2:60411/Images/ArticleImage/1.jpg");
        }
        
    }
}