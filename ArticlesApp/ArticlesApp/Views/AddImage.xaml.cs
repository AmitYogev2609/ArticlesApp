using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImage : ContentPage
    {
        public AddImage(SignInViewModel bc)
        {
            this.BindingContext = bc;
            ((SignInViewModel)this.BindingContext).SetImageSourceEvent += OnSetImageSource;
            bc.NavigateToEditeImage+= MoveToCropImage;
            bc.NavigateToPageEvent += NavigateToPageAsync;
            InitializeComponent();
        }
        public void NavigateToPageAsync()
        {
            Page page = new ChooseInterest((SignInViewModel)this.BindingContext);
            Navigation.PushAsync(page);
        }
        public void OnSetImageSource(ImageSource imgSource)
        {
            ProfileImage.Source = imgSource;

        }
        private void MoveToCropImage()
        {
           // Navigation.PushAsync(new CropImage((SignInViewModel)this.BindingContext));
            
        }

        private void MoveToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddImagePopUp(this.BindingContext));

        }
    }
    
}