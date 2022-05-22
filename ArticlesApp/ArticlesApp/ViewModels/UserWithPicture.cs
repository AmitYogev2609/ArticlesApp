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
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Security.Cryptography;
namespace ArticlesApp.ViewModels
{
    public class UserWithPicture
    {
        public User User { get; set; }
        public string PhotoUrl { get; set; }
        public string FulllName { get; set; }
        public string UserName { get; set; }
        public UserWithPicture(User user)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            PhotoUrl = $"{proxy.GetBasePhotoUri()}ArticleImage/{user.UserId}.jpg";
            //  Article = article;
            FulllName = user.FirstName + user.LastName;
            User = user;
            UserName = user.UserName;

        }

    }
}
