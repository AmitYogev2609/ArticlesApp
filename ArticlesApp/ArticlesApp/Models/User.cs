using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Services;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArticlesApp.Models
{
    public class User
    {
        public User()
        {
            ArticleReports = new List<ArticleReport>();
            AuthorsArticles = new List<AuthorsArticle>();
            Comments = new List<Comment>();
            FolloweduserFollowings = new List<Followeduser>();
            FolloweduserUsers = new List<Followeduser>();
            FollwedInterests = new List<FollwedInterest>();
            MessageReceivers = new List<Message>();
            MessageSenders = new List<Message>();
            UserReportReportedUsers = new List<UserReport>();
            UserReportUserIdReportedNavigations = new List<UserReport>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
        public bool IsManger { get; set; }

        public virtual ICollection<ArticleReport> ArticleReports { get; set; }
        public virtual ICollection<AuthorsArticle> AuthorsArticles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<FavoriteArticle> FavoriteArticles { get; set; }
        public virtual ICollection<Followeduser> FolloweduserFollowings { get; set; }
        public virtual ICollection<Followeduser> FolloweduserUsers { get; set; }
        public virtual ICollection<FollwedInterest> FollwedInterests { get; set; }
        public virtual ICollection<Message> MessageReceivers { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public virtual ICollection<UserReport> UserReportReportedUsers { get; set; }
        public virtual ICollection<UserReport> UserReportUserIdReportedNavigations { get; set; }
        
    }
}
