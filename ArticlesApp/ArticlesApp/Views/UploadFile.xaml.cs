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
    public partial class UploadFile : ContentPage
    {
        public UploadFile(AddArticleViewModel context)
        {
            this.BindingContext = context;
            context.navtoahow += navigate;
            InitializeComponent();
        }
        public void navigate()
        {
            Page page = new showBeforeUpload((AddArticleViewModel)this.BindingContext);
            Navigation.PushAsync(page);
        }
    }
}