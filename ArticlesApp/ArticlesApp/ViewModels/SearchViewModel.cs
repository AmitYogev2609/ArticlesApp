using System;
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
using System.Security.Cryptography;
namespace ArticlesApp.ViewModels
{
    
    class SearchViewModel
    {
        public ObservableCollection<object> searchResult { get; set; }
        public SearchViewModel()
        {
            searchResult = new ObservableCollection<object>();
            foreach (var item in ((App)App.Current).Articles)
            {
                searchResult.Add( new ArticleWithPicture(item, ((App)App.Current).User));
            }
            foreach (var item in ((App)App.Current).Interests)
            {
                searchResult.Add(item);
            }
            foreach (var item in ((App)App.Current).Users)
            {
                searchResult.Add( new UserWithPicture(item));
            }
            Shuffle(searchResult);
        }
        private static Random rng = new Random();
        public static void Shuffle(ObservableCollection<object> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                object value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
