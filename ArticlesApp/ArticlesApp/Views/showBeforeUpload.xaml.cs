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
    public partial class showBeforeUpload : ContentPage
    {
        public showBeforeUpload(AddArticleViewModel context)
        {
            this.BindingContext = context;
            context.finish += finishup;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            AddArticleViewModel context = (AddArticleViewModel)BindingContext;
            context.navtopop += NavigteToLoading;
            HtmlWebViewSource hmlsource = new HtmlWebViewSource();
            double width = App.Current.MainPage.Width;
            string htmlText = context.HtmlText;
            if (!htmlText.Contains("html"))
            { 
          
            htmlText = htmlText.Replace("width=\"auto\"", $"width =\"{width - 50}\"");
            hmlsource.Html = "<html>\n<head>\n<meta name=\"viewport\" content=\"width=device-width, initial-scale=1\" />\n</head>\n<body>\n";
            hmlsource.Html += htmlText;
            hmlsource.Html += "\n</body>\n</html>";
            }
            else
            {
                //htmlText = htmlText.Replace("<html>", $"<html width =\"100%\">");
                //htmlText = htmlText.Replace("<body>", $"<body width =\"100%\">");
                htmlText = htmlText.Replace("<head>", "<head>\n<meta name=\"viewport\" content=\"width=device-width, initial-scale =1\">");
                hmlsource.Html = htmlText;
            }
            webview.Source = hmlsource;
            AbsoluteLayout.SetLayoutBounds(webview, new Rectangle(0, 0, width, App.Current.MainPage.Height - 60));
        }
        public void finishup()
        {
            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PopAsync();
            Navigation.PopAsync();
        }
        private void NavigteToLoading(LoadingPopUp page)
        {
            Navigation.ShowPopup(page);
        }
    }
}