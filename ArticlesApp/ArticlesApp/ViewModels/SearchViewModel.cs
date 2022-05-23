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
        public static void Shuffle(ObservableCollection<object> list)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = list.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                object value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
