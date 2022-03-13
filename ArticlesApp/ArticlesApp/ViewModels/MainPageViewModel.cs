using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ArticlesApp.Views;
using ArticlesApp.Services;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace ArticlesApp.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<Article> Articles;
        public Color diviedColor { get=>new Color(196, 196, 196, 0.29);  }
        public Action<Popup> NavigateToPopup;
        public MainPageViewModel()
        {

        }
        public async void readData()
        {
            Popup loading= new LoadingPopUp();
            NavigateToPopup?.Invoke(loading);
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            Articles=new ObservableCollection<Article>( await proxy.GetUserArticles());
            ((LoadingPopUp)loading).DismisPopUP();
        }
    }
}
