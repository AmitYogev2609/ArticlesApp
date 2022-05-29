using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ArticlesApp.Services;
using System.Threading.Tasks;
namespace ArticlesApp.ViewModels
{
    public class ProfilePageViewModel
    {

        public UserWithPicture User { get; set; }
        public ObservableCollection<FollwedInterest> userIntrest { get; set; }
        public ObservableCollection<Followeduser> followedUsers { get; set; }
        public ObservableCollection<Followeduser> follwedBy { get; set; }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
        public ProfilePageViewModel(int userid)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            Task<User> user= proxy.GetUserDetails(userid);
            user.Wait();
            this.User= new UserWithPicture(user.Result);
            userIntrest = new ObservableCollection<FollwedInterest>(User.User.FollwedInterests);
            followedUsers = new ObservableCollection<Followeduser>(User.User.FolloweduserFollowings);
            follwedBy = new ObservableCollection<Followeduser>(User.User.FolloweduserUsers);
            articles = new ObservableCollection<ArticleWithPicture>();
            foreach (var item in User.User.AuthorsArticles)
            {
                articles.Add(new ArticleWithPicture(item.Article, User.User));
            }
        }
        public async  void GetUserDetails(int userid)
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();

            Task<User> tku =  proxy.GetUserDetails(userid);
            tku.Wait();
            this.User = new UserWithPicture(tku.Result);
            
        }

    }
}
