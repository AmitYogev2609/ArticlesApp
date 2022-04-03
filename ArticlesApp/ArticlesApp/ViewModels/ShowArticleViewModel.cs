using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using ArticlesApp.Services;

namespace ArticlesApp.ViewModels
{
    public class ShowArticleViewModel
    {
        public Article Article;
        public string Date { get; set; }
        public string Title { get; set; }
        public string Auther { get; set; }
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
                str += $" {item.User.UserName},";
            }
            return str;
        }
        public async void uptadeFavoriteArticle()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            ((App)App.Current).User = await proxy.UptadeFavoriteArticle(Article);
        }
    }
}
