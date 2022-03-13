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

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddArticleDetail : ContentPage
    {
        public  AddArticleDetail()
        {
            AddArticle context= new AddArticle();
            this.BindingContext = context;
            InitializeComponent();
            interstComboBox.DataSource = ((App)App.Current).Interests;
            interstComboBox.DisplayMemberPath = "InterestName";
            UserComboBox.DataSource = ((App)App.Current).Users;
            UserComboBox.DisplayMemberPath = "UserName";
           
        }
        
        
    }
}