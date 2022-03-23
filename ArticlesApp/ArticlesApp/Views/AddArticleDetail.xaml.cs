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
           
            List<int> indecies = (List<int>)interstComboBox.SelectedIndices;
            AddArticleViewModel context = (AddArticleViewModel)this.BindingContext;
            IEnumerable<Interest> lst =(IEnumerable<Interest>) interstComboBox.DataSource;
            foreach (var item in indecies)
            {
                context.ChooseIntrest.Add(lst.ToList<Interest>()[item]);
            }
            indecies = (List<int>)UserComboBox.SelectedIndices;
            IEnumerable<User> lst1 = (IEnumerable<User>)UserComboBox.DataSource;
            foreach (var item in indecies)
            {
                context.ChooseUser.Add(lst1.ToList<User>()[item]);
            }
          
           if(title.Text==null||title.Text=="")
           {
                pan.Border.Color = Color.Red;
                return;
           }
            if(editor.Text==null||editor.Text=="")
            {
                editor.Text = "man field";
                return;
            }
            if(context.ChooseIntrest.Count==0||context.ChooseUser.Count==0)
            {
                return;
            }
            Page page = new AddImageArticle((AddArticleViewModel)this.BindingContext);
            //List<Interest> intr=interests.ToList<Interest>();
            Navigation.PushAsync(page);
        }
        
    }
}