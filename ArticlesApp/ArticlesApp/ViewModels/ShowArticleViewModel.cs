using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
namespace ArticlesApp.ViewModels
{
    public class ShowArticleViewModel
    {
        public Article Article;
        public string Date;
        public string Title;
        public ShowArticleViewModel(Article article)
        {
            this.Article = article;
            Date= article.PublishDate.ToShortDateString();
            Title = article.ArticleName;
        }
    }
}
