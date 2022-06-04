using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Models;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Services;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CommentPage : ContentPage
    {
        public CommentPage(Article arti)
        {
            CommentPageViewModel context= new CommentPageViewModel(arti);
            this.BindingContext = context;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            CommentPageViewModel context=(CommentPageViewModel)this.BindingContext;
            context.Article.Comments.Clear();
            List<Comment> coms = await proxy.GetArticleComments(context.Article.ArticleId);
            foreach (Comment co in coms)
            {
                context.Article.Comments.Add(co);
            }
            context.fillData();
            base.OnAppearing();
        }

        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(colview.SelectedItem!=null)
            {
                CommentViewModel SelectedItem=(CommentViewModel)colview.SelectedItem;
                if(SelectedItem.User.User.UserId!=((App)App.Current).User.UserId)
                {
                    Page page = new ProfilePage(SelectedItem.User.User.UserId);
                    Navigation.PushAsync(page);
                }
            }
        }
    }
}