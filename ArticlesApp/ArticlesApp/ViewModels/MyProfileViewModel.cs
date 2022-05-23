using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace ArticlesApp.ViewModels
{
    class MyProfileViewModel
    {
        public UserWithPicture User { get; set; }
        public ObservableCollection<FollwedInterest> userIntrest { get; set; }
        public ObservableCollection<Followeduser> followedUsers { get; set; }
        public ObservableCollection<Followeduser> follwedBy { get; set; }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
        public MyProfileViewModel(User user)
        {
            User = new UserWithPicture(user);
            userIntrest= new ObservableCollection<FollwedInterest>(user.FollwedInterests);
            followedUsers = new ObservableCollection<Followeduser>(user.FolloweduserFollowings);
            follwedBy = new ObservableCollection<Followeduser>(user.FolloweduserUsers);
            articles = new ObservableCollection<ArticleWithPicture>();
            foreach (var item in user.AuthorsArticles)
            {
                articles.Add(new ArticleWithPicture(item.Article,user));
            }
        }
        
    }
}
