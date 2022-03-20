using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.CommunityToolkit.Extensions;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImageArticle : ContentPage
    {
        public AddImageArticle(AddArticleViewModel context)
        {
            this.BindingContext = context;
            context.NaviagteToAddarticle += NavigaeToPage;
            InitializeComponent();
            
            ((AddArticleViewModel)this.BindingContext).SetImageSourceEvent += OnSetImageSource;

        }
        private void MoveToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddImagePopUp(this.BindingContext));

        }
        private void NavigaeToPage()
        {
            Page page = new AddArticle((AddArticleViewModel)this.BindingContext);
            Navigation.PushAsync(page);
        }
        public void OnSetImageSource(ImageSource imgSource)
        {
            ProfileImage.Source = imgSource;

        }
    }
}