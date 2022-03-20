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
    public partial class showBeforeUpload : ContentPage
    {
        public showBeforeUpload(AddArticleViewModel context)
        {
            this.BindingContext = context;

            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddArticleViewModel context = (AddArticleViewModel)BindingContext;
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();
            string htmlText = context.HtmlText;
            double width = App.Current.MainPage.Width;
            htmlText = htmlText.Replace("width=\"auto\"", $"width =\"{width - 50}\"");
            hmlsource.Html = "<html>\n<body>\n";
            hmlsource.Html += htmlText;
            hmlsource.Html += "\n</body>\n</html>";
            webview.Source = hmlsource;
            AbsoluteLayout.SetLayoutBounds(webview, new Rectangle(0, 0, width, App.Current.MainPage.Height - 60));
        }
    }
}