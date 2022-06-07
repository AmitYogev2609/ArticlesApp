using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using ArticlesApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ArticlesApp.ViewModels
{
    public class AdminPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ObservableCollection<Interest> Interests { get; set; }
        public ObservableCollection<User> Users { get; set; }
        public ObservableCollection<Article> Articles { get; set; }

        private string newIntrestName;
        public string NewIntrestName { get=>newIntrestName; set
            {
                if(value!=newIntrestName)
                {
                    newIntrestName=value;
                    OnPropertyChanged(nameof(NewIntrestName));
                }
            } }
        public AdminPageViewModel()
        {
            Interests = new ObservableCollection<Interest>();
            List<Interest> list = ((App)App.Current).Interests;
            foreach (var item in list)
            {
                Interests.Add(item);
            }
            Users = new ObservableCollection<User>();
            List<User> lst = ((App)App.Current).Users;
            foreach (var item in lst)
            {
                Users.Add(item);
            }
            Articles = new ObservableCollection<Article>();
            List<Article> lstar= ((App)App.Current).Articles;
            foreach (var item in lstar)
            {
                Articles.Add(item);
            }
        }
        public ICommand AddInterestCommand => new Command(AddInterest);
        public async void AddInterest()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            if(this.NewIntrestName==""|| this.NewIntrestName == null || this.NewIntrestName == " ")
            {
                return ;
            }
            else
            {
                Interest newInterest =await proxy.AddInterest(this.NewIntrestName);
                this.Interests.Add(newInterest);
                ((App)App.Current).Interests.Add(newInterest);
                this.NewIntrestName = "";
            }
        }
        private int usertomakeadmin;
        public int UserToMakeAdmin { get=>usertomakeadmin; set 
            {
                if(usertomakeadmin!=value)
                {
                    usertomakeadmin = value;
                    OnPropertyChanged(nameof(UserToMakeAdmin));
                }
            } }
        public ICommand makeMange => new Command(makeUser);
        public async void makeUser()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            bool con = await proxy.MakeUserAdmin(this.UserToMakeAdmin);
            ((App)App.Current).User.IsManger = con;
        }
        private int interestid;
        public int InterestId
        {
            get => interestid; set
            {
                if (interestid != value)
                {
                    interestid = value; OnPropertyChanged(nameof(InterestId));
                }
            }
        }
        private int userid;
        public int UserId { get=>userid; set { 
                if(userid!=value)
                {
                    userid = value; OnPropertyChanged(nameof(UserId));
                }
            } }
        private int articleid;
        public int ArticleId
        {
            get => articleid; set
            {
                if (articleid != value)
                {
                    articleid = value; OnPropertyChanged(nameof(ArticleId));
                }
            }
        }
    }
}
