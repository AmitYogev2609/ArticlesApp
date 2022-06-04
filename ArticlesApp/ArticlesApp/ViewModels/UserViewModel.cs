using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Views;
using ArticlesApp.Models;
using ArticlesApp.Services;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArticlesApp.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private int userid;
        private string username;
        public string UserName
        {
            get => username; set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }
        private string buttontext;
        public string ButtonText
        {
            get => buttontext; set
            {
                if (buttontext != value)
                {
                    buttontext = value;
                    OnPropertyChanged(nameof(ButtonText));
                }
            }
        }
        private Color buttontextcolor;
        public Color ButtonTextColor
        {
            get => buttontextcolor; set
            {
                if (buttontextcolor != value)
                {
                    buttontextcolor = value;
                    OnPropertyChanged(nameof(ButtonTextColor));
                }
            }
        }
        private Color buttonbackcolor;
        public Color ButtonBackColor
        {
            get => buttonbackcolor; set
            {
                if (value != buttonbackcolor)
                {
                    buttonbackcolor = value;
                    OnPropertyChanged(nameof(ButtonBackColor));
                }
            }
        }
        public bool isFollwing;
        public User User;
        private string photourl;
        public string PhotoUrl
        {
            get => photourl; set
            {
                if (photourl != value)
                {
                    photourl = value;
                    OnPropertyChanged(nameof(PhotoUrl));
                }
            }
        }
        private string fullname;
        public string FullName
        {
            get => fullname; set
            {
                if (fullname != value)
                {
                    fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }
        private bool isvisable;
        public bool IsVisable { get=>isvisable; set { 
            if (isvisable != value)
                {
                    isvisable = value;
                    OnPropertyChanged(nameof(IsVisable));
                }
            } }
        public UserViewModel(User user)
        {
            this.User = user;

            User logduser = ((App)App.Current).User;
            IsVisable = true;
            if (logduser.UserId == this.User.UserId)
            {
                IsVisable = false;
                this.FullName = "me";
            }
            this.FullName= this.User.FirstName+" " + this.User.LastName;
            this.userid = user.UserId;
            this.UserName = user.UserName;
            isFollwing = false;
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            PhotoUrl = $"{proxy.GetBasePhotoUri()}UserImage/{user.UserId}.jpg";
            if(IsVisable)
            { 
            foreach (var item in logduser.FolloweduserUsers)
            {
                if (item.FollowingId == user.UserId)
                {
                    isFollwing = true;
                }
            }
            if (isFollwing)
            {
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonBackColor = Color.FromHex("#ECECF1");
                ButtonText = "unfollow";
            }
            else
            {
                ButtonTextColor = Color.White;
                ButtonText = "follow";
                ButtonBackColor = Color.FromHex("#2934D0");
            }
            }
        }
        public ICommand buttonPresscommand => new Command<UserViewModel>(buttonPress);
        public async void buttonPress(UserViewModel userViewModel)
        {

            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            if (userViewModel.isFollwing)
            {
                ((App)App.Current).User = await proxy.UnFollowUser(userid);
                ButtonTextColor = Color.White;
                ButtonText = "follow";
                ButtonBackColor = Color.FromHex("#2934D0");
                isFollwing = false;
            }
            else
            {
                ((App)App.Current).User = await proxy.FollowUser(userid);
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonBackColor = Color.FromHex("#ECECF1");
                ButtonText = "unfollow";
                isFollwing = true;
            }
        }
    }
}
