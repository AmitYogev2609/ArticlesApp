using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InterestPage : ContentPage
    {
        public Action ac;
        public InterestPage(int interestid, Action ac)
        {
            Interest interest = ((App)App.Current).Interests.Find(u => u.InterestId == interestid);
            InterestPageViewModel context = new InterestPageViewModel(interest, ((App)App.Current).User);
            this.BindingContext = context;
            context.ac = ac;
            InitializeComponent();
            this.ac = ac;
        }
        public InterestPage(int interestid)
        {
            Interest interest = ((App)App.Current).Interests.Find(u => u.InterestId == interestid);
            this.BindingContext = new InterestPageViewModel(interest, ((App)App.Current).User);
            InitializeComponent();
            
        }
        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ArticleWithPicture articleWithPicture = (ArticleWithPicture)colview.SelectedItem;
            if (articleWithPicture != null)
            {
                Page page = new ShowArticle(articleWithPicture, colview);
                colview.SelectedItem = null;
                Navigation.PushAsync(page);
            }
        }
        protected override void OnDisappearing()
        {
            
            base.OnDisappearing();
        }
    }
}