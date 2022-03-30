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
    public  class Article
    {
        public Article()
        {
            ArticleInterestTypes = new List<ArticleInterestType>();
            ArticleReports = new List<ArticleReport>();
            AuthorsArticles = new List<AuthorsArticle>();
            Comments = new List<Comment>();
        }

        public int ArticleId { get; set; }
        public string HtmlText { get; set; }
        public string ArticleName { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }


        public virtual ICollection<ArticleInterestType> ArticleInterestTypes { get; set; }
        public virtual ICollection<ArticleReport> ArticleReports { get; set; }
        public virtual ICollection<AuthorsArticle> AuthorsArticles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
              
    }
}
