using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Services;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddArticleDetail : ContentPage
    {
        public  AddArticleDetail()
        {
            AddArticleViewModel context= new AddArticleViewModel();
            this.BindingContext = context;
            context.NavigateToPageEvent += NavigateToPage;
            InitializeComponent();
            interstComboBox.DataSource = ((App)App.Current).Interests;
            interstComboBox.DisplayMemberPath = "InterestName";
            UserComboBox.DataSource = ((App)App.Current).Users;
            UserComboBox.DisplayMemberPath = "UserName";
            
           
        }
        public void NavigateToPage()
        {
            Page page = new AddImageArticle((AddArticleViewModel)this.BindingContext);
          
           object interests=interstComboBox.SelectedItem;
            Type type = interstComboBox.SelectedItem.GetType();
            string str = type.FullName;
            //List<Interest> intr=interests.ToList<Interest>();
            Navigation.PushAsync(page);
        }
        
    }
}