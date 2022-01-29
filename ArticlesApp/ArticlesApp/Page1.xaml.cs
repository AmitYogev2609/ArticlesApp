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
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            Task<List<Interest>> taskinterests=  proxy.GetInitialInterests();
            taskinterests.Wait();
            List<Interest> interests= taskinterests.Result;
            InitializeComponent();
            test.ItemsSource = interests;
        }
    }
}