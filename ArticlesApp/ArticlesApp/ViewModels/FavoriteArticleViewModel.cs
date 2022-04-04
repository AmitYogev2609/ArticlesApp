﻿using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ArticlesApp.Views;
using ArticlesApp.Services;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;

namespace ArticlesApp.ViewModels
{
    class FavoriteArticleViewModel
    {
        ObservableCollection<ArticleWithPicture> Articles;
        public FavoriteArticleViewModel()
        {
            Articles = new ObservableCollection<ArticleWithPicture>();
            User user = ((App)App.Current).User;
            foreach (var item in user.FavoriteArticles)
            {
                Articles.Add(new ArticleWithPicture(item.Article));
            }
        }
    }
}
