using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using ArticlesApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
namespace ArticlesApp.ViewModels
{
    public class ShowArticleViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Article Article;
        public string Date { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
        private string commentText;
        public string CommentText { get=>commentText; set
            {
                if(commentText !=value)
                {
                    commentText = value;
                    OnPropertyChanged(nameof(CommentText));
                }
            }
        }
        public ShowArticleViewModel(Article article)
        {
            this.Article = article;
            Date= article.PublishDate.ToShortDateString();
            Title = article.ArticleName;
            Auther = getAthours(article); 
        }
        private string getAthours(Article article)
        {
          
            string str = "by:";
            foreach (var item in Article.AuthorsArticles)
            {
               if(item.User!=null)
                str += $" {item.User.UserName},";
            }
            return str;
        }
        public async void uptadeFavoriteArticle()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            ((App)App.Current).User = await proxy.UptadeFavoriteArticle(Article);
        }
        public async void RemoveFavoriteArticle()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            ((App)App.Current).User = await proxy.RemoveFavoriteArticle(Article);
            
        }
        public ICommand addACommentCommand =>new Command(addAComment);
        public async void addAComment()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            Comment comment= new Comment()
            {
                UserId=((App)App.Current).User.UserId,
                ArticleId=this.Article.ArticleId,
                Text=this.CommentText
            };
            comment = await proxy.UploadComment(comment);
            this.Article.Comments = await proxy.GetArticleComments(this.Article.ArticleId);
            comment.User = ((App)App.Current).User;
            comment.Article = this.Article;
            ((App)App.Current).User.Comments.Add(comment);
            this.CommentText = "";

        }
    }
}
