using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentView
    {
        public SearchPage()
        {
            SearchViewModel context = new SearchViewModel();
            this.BindingContext = context;
            InitializeComponent();
            
           
        }
        SearchBar searchBar = null;
        private void OnFilterTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchViewModel context = (SearchViewModel)this.BindingContext;
            if(listView.ItemsSource==null)
            {
                listView.ItemsSource = context.searchResult;
            }
            searchBar = (sender as SearchBar);
            if (listView.DataSource != null)
            {
                this.listView.DataSource.Filter = FilterContacts;
                this.listView.DataSource.RefreshFilter();
            }
        }

        private bool FilterContacts(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;
            if(obj is ArticleWithPicture )
            {
                var arti = obj as ArticleWithPicture;
                if (arti.Article.ArticleName.ToLower().StartsWith(searchBar.Text.ToLower()))
                    return true;
            }
            if(obj is UserWithPicture)
            {
                var arti = obj as UserWithPicture;
                if (arti.User.UserName.ToLower().StartsWith(searchBar.Text.ToLower()))
                    return true;
            }
            if (obj is Interest)
            {
                var arti = obj as Interest;
                if (arti.InterestName.ToLower().StartsWith(searchBar.Text.ToLower()))
                    return true;
            }
            return false;
            //var contacts = obj as Contacts;
            //if (contacts.ContactName.ToLower().Contains(searchBar.Text.ToLower())
            //     || contacts.ContactName.ToLower().Contains(searchBar.Text.ToLower()))
            //    return true;
            //else
            //    return false;
        }

        private void listView_SelectionChanged(object sender, Syncfusion.ListView.XForms.ItemSelectionChangedEventArgs e)
        {

                List<object> list = e.AddedItems.ToList<object>();
                object obj = list[0];
                if (obj is ArticleWithPicture)
                {
                    var arti = obj as ArticleWithPicture;
                    ShowArticle page = new ShowArticle(arti);
                    Navigation.PushAsync(page);
                }
                if (obj is Interest)
                {
                    var interest = obj as Interest;
                    ViewInterest page = new ViewInterest(interest.InterestId);
                    Navigation.PushAsync(page);
                }

            listView.SelectedItem = null;
            listView.SelectedItems.Clear();
        }
    }
}