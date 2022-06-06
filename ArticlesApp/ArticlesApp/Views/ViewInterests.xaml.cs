using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using ArticlesApp.Services;
using ArticlesApp.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewInterests : ContentPage
    {
        public User user;
        public bool IsMain;
        public ViewInterests(List<Interest> list, User user,string title,bool Ismain= true)
        {
            ViewInterestsViewModel context = new ViewInterestsViewModel(list);
            this.BindingContext = context;
            InitializeComponent();
            this.user = user;
            this.IsMain = Ismain;
            ti.Text= title;
        }
        public Action acs;
        public ViewInterests(List<Interest> list,Action ac,User user, string title,bool Ismain=true)
        {
            ViewInterestsViewModel context = new ViewInterestsViewModel(list);
            this.BindingContext = context;
            InitializeComponent();
            acs=ac;
            this.user = user;
            this.IsMain=Ismain;
            ti.Text = title;
        }
        private void colview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(colview.SelectedItem != null)
            {
                InterestViewModel interest = (InterestViewModel)colview.SelectedItem;

                Page page = new InterestPage(interest.Interest.InterestId );
                if(acs!=null)
                { 
                    page = new InterestPage(interest.Interest.InterestId,acs);
                }
                
                Navigation.PushAsync(page);
            }

        }
        protected override void OnAppearing()
        {
            if(this.IsMain)
            { 
            List<Interest> interests = new List<Interest>();
           
            foreach (var item in user.FollwedInterests)
            {
                interests.Add(item.Interest);
            }
            ViewInterestsViewModel context=(ViewInterestsViewModel)this.BindingContext;
            context.update(interests);
            }
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            if (acs != null)
                acs?.Invoke();
            base.OnDisappearing();
        }
       
    }
}