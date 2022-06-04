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
    public class UserWithPicture:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public User User { get; set; }
        private string photourl;
        public string PhotoUrl { get=>photourl; set { 
            if(photourl!= value)
                {
                    photourl = value;
                    OnPropertyChanged(PhotoUrl);
                }
            } }
        public string FulllName { get; set; }
        public string UserName { get; set; }
        public UserWithPicture(User user)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            PhotoUrl = $"{proxy.GetBasePhotoUri()}UserImage/{user.UserId}.jpg";
            //  Article = article;
            FulllName = user.FirstName + " "+ user.LastName;
            User = user;
            UserName = user.UserName;

        }

    }
}
