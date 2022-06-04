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
    public  class InterestViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private int interestid;
        private string interestname;
        public string InterestName { get=>interestname; set
            {
                if(interestname != value)
                {
                    interestname = value;
                    OnPropertyChanged(nameof(InterestName));
                }
            } }
        private string buttontext;
        public string ButtonText { get=>buttontext; set
            {
                if(buttontext != value)
                {
                    buttontext = value;
                    OnPropertyChanged(nameof(ButtonText));
                }
            } }
        private Color buttontextcolor;
        public Color ButtonTextColor { get=>buttontextcolor; set
            {
                if (buttontextcolor != value)
                {
                    buttontextcolor = value;
                    OnPropertyChanged(nameof(ButtonTextColor));
                }
            } }
        private Color buttonbackcolor;
        public Color ButtonBackColor { get=>buttonbackcolor; set
            {
                if(value!=buttonbackcolor)
                {
                    buttonbackcolor = value;
                    OnPropertyChanged(nameof(ButtonBackColor));
                }
            } }
        public bool isFollwing;
        public Interest Interest;
        public int numOfArticle { get; set; }
        public InterestViewModel(Interest interest)
        {
            this.Interest = interest;
            this.numOfArticle = interest.ArticleInterestTypes.Count;
            User user = ((App)App.Current).User;
            this.interestid = interest.InterestId;
            this.InterestName=interest.InterestName;
            isFollwing = false;
            foreach (var item in user.FollwedInterests)
            {
                if(item.InterestId == interest.InterestId)
                {
                    isFollwing = true;
                }
            }
            if(isFollwing)
            {
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonBackColor = Color.FromHex("#ECECF1") ;
                ButtonText = "unfollow";
            }
            else
            {
                ButtonTextColor = Color.White;
                ButtonText = "follow";
                ButtonBackColor = Color.FromHex("#2934D0");
            }
        }
        public ICommand buttonPresscommand => new Command<InterestViewModel>(buttonPress);
        public async void buttonPress(InterestViewModel interestViewModel)
        {
            
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            if(interestViewModel.isFollwing)
            {
                ((App)App.Current).User = await proxy.UnFollewIntrest(((App)App.Current).User.UserId, interestViewModel.interestid);
                ButtonTextColor = Color.White;
                ButtonText = "follow";
                ButtonBackColor = Color.FromHex("#2934D0");
                isFollwing=false;
            }
            else
            {
                ((App)App.Current).User = await proxy.FollewIntrest(((App)App.Current).User.UserId, interestViewModel.interestid);
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonBackColor = Color.FromHex("#ECECF1");
                ButtonText = "unfollow";
                isFollwing = true;
            }
        }
    }
}
