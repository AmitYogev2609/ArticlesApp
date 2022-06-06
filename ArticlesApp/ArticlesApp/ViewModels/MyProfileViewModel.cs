using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Views;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace ArticlesApp.ViewModels
{
    class MyProfileViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private UserWithPicture user;
        public UserWithPicture User { get=>user; set
            {
                if(user != value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            } }
        public ObservableCollection<FollwedInterest> userIntrest { get; set; }
        public ObservableCollection<Followeduser> followedUsers { get; set; }
        public ObservableCollection<Followeduser> follwedBy { get; set; }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
        public MyProfileViewModel(User user)
        {
            User = new UserWithPicture(user);
            userIntrest= new ObservableCollection<FollwedInterest>(user.FollwedInterests);
             follwedBy = new ObservableCollection<Followeduser>(user.FolloweduserFollowings);
            followedUsers = new ObservableCollection<Followeduser>(user.FolloweduserUsers);
            articles = new ObservableCollection<ArticleWithPicture>();
            foreach (var item in user.AuthorsArticles)
            {
                articles.Add(new ArticleWithPicture(item.Article,user));
            }
        }
        public void refresh()
        {
            User user = ((App)App.Current).User;
            User = new UserWithPicture(user);
            userIntrest.Clear();
            foreach (var item in user.FollwedInterests)
            {
                userIntrest.Add(item);
            }
            follwedBy.Clear();
            foreach (var item in user.FolloweduserFollowings)
            {
                follwedBy.Add(item);
            }
            followedUsers.Clear();
            foreach (var item in user.FolloweduserUsers)
            {
                followedUsers.Add(item);
            }
            articles.Clear();
            foreach (var item in user.AuthorsArticles)
            {
                articles.Add(new ArticleWithPicture(item.Article, user));

            }
        }
        public Action<Page> navigateTopage;
        public ICommand moveToViewInterestsCommmand =>new Command(moveToViewInterests);
        public void moveToViewInterests()
        {
            List<Interest> interestslist= new List<Interest>();
            foreach (var item in user.User.FollwedInterests)
                interestslist.Add(item.Interest);
            Page page = new ViewInterests(interestslist,((App)App.Current).User, "My Interests");
            if (ac != null)
                page = new ViewInterests(interestslist, ac, ((App)App.Current).User, "My Interests");
            navigateTopage?.Invoke(page);
        }
        public Action ac;
        public ICommand movetoViewUsersCommand1 => new Command(movetoViewUsers);
        public void movetoViewUsers()
        {
            
            List<User> users= new List<User>();
            
            
                foreach (var item in followedUsers)
                {
                    users.Add(item.Following);
                }
            Page page = new ViewUsers(users, "Pepole i follow", ac);
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
            Page page = new ViewUsers(users, "My followers", ac);
            navigateTopage?.Invoke(page);
        }

    }
}
