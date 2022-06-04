using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using ArticlesApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ArticlesApp.Views;
using System.Linq;
namespace ArticlesApp.ViewModels
{
    public class ProfilePageViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private UserWithPicture user;
        public UserWithPicture User { get=>user; set { 
                if (user != value) 
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                } } }
        public int userid;
        public ObservableCollection<FollwedInterest> userIntrest { get; set; }
        public ObservableCollection<Followeduser> followedUsers { get; set; }
        public ObservableCollection<Followeduser> follwedBy { get; set; }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
        private string text;
        public string Text { get=>text; set
            {
                if(text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            } }
        private Color bttextcolor;
        public Color BtTextColor { get=>bttextcolor; set
            {
                if(bttextcolor != value)
                {
                    bttextcolor = value;
                    OnPropertyChanged(nameof (BtTextColor));
                }
            } }
        private Color btbackcolor;
        public Color BtBackColor { get=>btbackcolor; set
            {
                if( btbackcolor != value)
                {
                    btbackcolor = value;
                    OnPropertyChanged(nameof(BtBackColor));
                }
            } }
        public ProfilePageViewModel(int userid)
        {
            this.userid = userid;
            userIntrest = new ObservableCollection<FollwedInterest>();
            followedUsers = new ObservableCollection<Followeduser>();
            follwedBy = new ObservableCollection<Followeduser>();
            articles = new ObservableCollection<ArticleWithPicture>();
            
        }
        public ICommand buttonPress => new Command(buttonpress);
        public async void buttonpress()
        {
            bool ext = false;
            User us = this.User.User;
            foreach (var item in us.FolloweduserFollowings)
            {
                if (item.UserId == ((App)App.Current).User.UserId)
                    ext = true;
            }
            if (ext)
            {
                ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
                ((App)App.Current).User = await proxy.UnFollowUser(userid);
                User.User = await proxy.GetUserDetails(userid);
                follwedBy.Clear();
                foreach (var item in User.User.FolloweduserFollowings)
                {
                   follwedBy.Add(item);
                }
                BtTextColor = Color.White;
                Text = "follow";
                BtBackColor = Color.FromHex("#2934D0");
            }
            else
            {
                ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
                ((App)App.Current).User = await proxy.FollowUser(userid);
                User.User = await proxy.GetUserDetails(userid);
                follwedBy.Clear();
                foreach (var item in User.User.FolloweduserFollowings)
                {
                    follwedBy.Add(item);
                }
                BtBackColor = Color.FromHex("#ECECF1");
                BtTextColor = Color.FromHex("#2934D0");
                Text = "unfollow";
            }
        }
       public void inButton()
       {
            bool ext = false;
            User us = this.User.User;
            foreach (var item in us.FolloweduserFollowings)
            {
                if(item.UserId==((App)App.Current).User.UserId)
                    ext = true;
            }
            if(ext)
            {
                BtBackColor = Color.FromHex("#ECECF1");
                BtTextColor = Color.FromHex("#2934D0");
                Text = "unfollow";
            }
            else
            {
                BtTextColor = Color.White;
                Text = "follow";
                BtBackColor = Color.FromHex("#2934D0");
            }
       }
        public ICommand moveToViewInterestsCommmand => new Command(moveToViewInterests);
        public void moveToViewInterests()
        {
            List<Interest> interestslist = new List<Interest>();
            foreach (var item in user.User.FollwedInterests)
                interestslist.Add(item.Interest);
            Page page = new ViewInterests(interestslist,user.User);
           
            navigateTopage?.Invoke(page);
        }
        public Action<Page> navigateTopage;
        public ICommand movetoViewUsersCommand1 => new Command(movetoViewUsers);
        public void movetoViewUsers()
        {

            List<User> users = new List<User>();


            foreach (var item in followedUsers)
            {
                users.Add(item.Following);
            }
            
            Page page = new ViewUsers(users);
            navigateTopage?.Invoke(page);


        }
        public ICommand movetoViewUsersCommand2 => new Command(movetoViewUsers2);
        public void movetoViewUsers2()
        {
            int num = 1;
            List<User> users = new List<User>();

            foreach (var item in follwedBy)
            {
                users.Add(item.User);
            }
           
            Page page = new ViewUsers(users);
            navigateTopage?.Invoke(page);
        }
    }
}
