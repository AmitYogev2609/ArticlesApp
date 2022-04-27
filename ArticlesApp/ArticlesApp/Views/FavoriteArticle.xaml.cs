using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteArticle : ContentView
    {
        public double PageWidth { get; set; }
        public FavoriteArticle()
        {
            
            PageWidth = App.Current.MainPage.Width-60;
            PageWidth = PageWidth / 2;
            FavoriteArticleViewModel vm = new FavoriteArticleViewModel();
            vm.PageWidth = PageWidth;
            this.BindingContext = vm;
            InitializeComponent();
            
            
        }

        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArticleWithPicture articleWithPicture = (ArticleWithPicture)colview.SelectedItem;
            if (articleWithPicture != null)
            {
                Page page = new ShowArticle(articleWithPicture,colview);
                colview.SelectedItem = null;
                Navigation.PushAsync(page);
            }
        }
            
    }
}