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
            AddArticleViewModel context = (AddArticleViewModel)this.BindingContext;
            //extract interest
            List<int> indecies = new List<int>();

            if((IEnumerable<int>)interstComboBox.SelectedIndices==null)
            {
                interstComboBox.Watermark= "must Pick at least on intrest";
                interstComboBox.BorderColor = Color.Red;
                return;
            }
            foreach (int val in (IEnumerable<int>)interstComboBox.SelectedIndices)
            { 
                indecies.Add(val);
            }
            if (indecies.Count==0)
            {
                interstComboBox.Watermark = "must Pick at least on intrest";
                interstComboBox.BorderColor = Color.Red;

                return;
            }
            IEnumerable<Interest> lst =(IEnumerable<Interest>) interstComboBox.DataSource;
            foreach (var item in indecies)
            {
                context.ChooseIntrest.Add(lst.ToList<Interest>()[item]);
            }
            indecies.Clear();
            //extract users
            IEnumerable<User> lst1 = (IEnumerable<User>)UserComboBox.DataSource;
            if((IEnumerable<int>)UserComboBox.SelectedIndices!=null)
            { 
                foreach (int val in (IEnumerable<int>)UserComboBox.SelectedIndices)
                {
                    indecies.Add(val);
                }
                foreach (var item in indecies)
                {
                    context.ChooseUser.Add(lst1.ToList<User>()[item]);
                }
            }
            
            if (title.Text==null||title.Text=="")
            {
                pan.Border.Color = Color.Red;
                return;
            }
            if(editor.Text==null||editor.Text=="")
            {
                editor.Text = "man field";
                return;
            }
           
            Page page = new AddImageArticle((AddArticleViewModel)this.BindingContext);
            //List<Interest> intr=interests.ToList<Interest>();
            Navigation.PushAsync(page);
        }
        
    }
}