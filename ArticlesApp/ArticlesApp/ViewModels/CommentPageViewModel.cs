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
    public class CommentPageViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ObservableCollection<CommentViewModel> Comments { get; set; }
        public Article Article { get; set; }
        private string text;
        public string Text
        {
            get => text; set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
        public CommentPageViewModel(Article article)
        {
            Article = article;
            Comments = new ObservableCollection<CommentViewModel>();
        }
        public void fillData()
        {
            Comments.Clear();
            foreach (Comment comment in Article.Comments)
            {
                Comments.Add(new CommentViewModel(comment));
            }
        }
        public ICommand addACommentCommand => new Command(addAComment);
        public async void addAComment()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            Comment comment = new Comment()
            {
                UserId = ((App)App.Current).User.UserId,
                ArticleId = this.Article.ArticleId,
                Text = this.text
            };
            comment= await proxy.UploadComment(comment);
            this.Article.Comments = await proxy.GetArticleComments(Article.ArticleId);
            ((App)App.Current).User.Comments.Add(comment);
            this.Text = "";
            this.Comments.Add(new CommentViewModel(comment));

        }
    }
}
