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
        public int userid;
        public ObservableCollection<FollwedInterest> userIntrest { get; set; }
        public ObservableCollection<Followeduser> followedUsers { get; set; }
        public ObservableCollection<Followeduser> follwedBy { get; set; }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
        public ProfilePageViewModel(int userid)
        {
            this.userid = userid;
            userIntrest = new ObservableCollection<FollwedInterest>();
            followedUsers = new ObservableCollection<Followeduser>();
            follwedBy = new ObservableCollection<Followeduser>();
            articles = new ObservableCollection<ArticleWithPicture>();
            
        }
       

    }
}
