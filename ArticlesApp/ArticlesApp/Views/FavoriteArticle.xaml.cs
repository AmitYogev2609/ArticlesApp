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
        public FavoriteArticle()
        {
            this.BindingContext = new FavoriteArticleViewModel(); 
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