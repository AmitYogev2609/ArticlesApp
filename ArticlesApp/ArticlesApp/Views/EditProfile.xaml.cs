using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using ArticlesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.Extensions;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProfile : ContentPage
    {
        public Action shac;
        public EditProfile(ImageSource imageSource, Action action)
        {
            EditProfileViewModel viewModel = new EditProfileViewModel();
            BindingContext = viewModel;
            viewModel.SetImageSourceEvent += OnSetImageSource;
           shac=action;
            InitializeComponent();
            ProfileImage.Source=imageSource;
        }
        private void MoveToPopUp(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new AddImagePopUp(this.BindingContext));

        }
        private void EmailEntry_Unfocused(object sender, FocusEventArgs e)
        {
            ((EditProfileViewModel)this.BindingContext).ValidateEmail();
        }

        private void UserName_Unfocused(object sender, FocusEventArgs e)
        {
            ((EditProfileViewModel)this.BindingContext).ValdateUserName();
        }

        private void FullName_Unfocused(object sender, FocusEventArgs e)
        {
            ((EditProfileViewModel)this.BindingContext).ValdateFullName();
        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            ProfileImage.Source = imgSource;

        }
        protected override void OnDisappearing()
        {
            shac?.Invoke();
            base.OnDisappearing();
        }
        
    }
}
