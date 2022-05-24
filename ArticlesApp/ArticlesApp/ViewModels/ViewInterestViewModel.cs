using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using ArticlesApp.Services;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
namespace ArticlesApp.ViewModels
{
    public class ViewInterestViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Interest Interest { get; set; }
        private string buttontext;
        public string ButtonText { get=>buttontext; set 
            {
                if(buttontext != value)
                {
                    buttontext = value;
                    OnPropertyChanged(nameof(ButtonText));
                }
            } }
        private Color buttontextcolor;
        public Color ButtonTextColor { get=>buttontextcolor; set
            {
                if(buttontextcolor != value)
                {
                    buttontextcolor = value;
                    OnPropertyChanged(nameof(ButtonTextColor));
                }
            } }
        private Color buttonbackgroundcolor;
        public Color ButtonBackgroundColor { get=>buttonbackgroundcolor; set 
            {
                if(buttonbackgroundcolor != value)
                {
                    buttonbackgroundcolor = value;
                    OnPropertyChanged(nameof (ButtonBackgroundColor));
                }
            } }
        public ObservableCollection<ArticleWithPicture> articles { get; set; }
       
        public ViewInterestViewModel(Interest interest,User user)
        {
            this.Interest = interest;
            List<Article> articles1 = new List<Article>();
            foreach (var item in interest.ArticleInterestTypes)
            {
                if (!articles1.Contains(item.Article))
                    articles1.Add(item.Article);
            }
           articles1= articles1.OrderByDescending(a => a.ArticleId).ToList<Article>();
            articles = new ObservableCollection<ArticleWithPicture>();
            foreach (var item in articles1)
            {
                articles.Add(new ArticleWithPicture(item,user));
            }
            bool con = false;
            foreach (var item in user.FollwedInterests)
            {
                if (item.InterestId == interest.InterestId)
                    con = true;
            }
            if (con)
            {
                ButtonBackgroundColor = Color.FromHex("#ECECF1");
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonText = "unfollow";
            }
            else
            {
                ButtonBackgroundColor = Color.FromHex("#2934D0");
                ButtonTextColor = Color.White;
                ButtonText = "follow";
            }
            List<ArticleWithPicture> articleWithPictures = new List<ArticleWithPicture>();
        }
        public ICommand ButtonPress => new Command(buttonPress);
        public async void buttonPress()
        {
            User user= ((App)App.Current).User;

            //remove
            Interest interest = ((App)App.Current).Interests.Find(u => u.InterestId == this.Interest.InterestId);
            FollwedInterest fu=null;
            foreach (var item in interest.FollwedInterests)
            {
                if (item.InterestId == interest.InterestId && item.UserId == user.UserId)
                    fu = item;
            }
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();

            if(fu != null)
            {
                //remove 
                ((App)App.Current).User =await proxy.UnFollewIntrest(user.UserId, interest.InterestId);
                interest.FollwedInterests.Remove(fu);
                user.FollwedInterests.Remove(fu);
                ButtonBackgroundColor = Color.FromHex("#2934D0");
                ButtonTextColor = Color.White;
                ButtonText = "follow";
            }
            else
            {
                //add
                ((App)App.Current).User = await proxy.FollewIntrest(user.UserId, interest.InterestId);

                interest.FollwedInterests.Add(new FollwedInterest()
                {
                    InterestId = interest.InterestId,
                    UserId = user.UserId,
                    User = user,
                    Interest = interest,
                });
                
                ButtonBackgroundColor = Color.FromHex("#ECECF1");
                ButtonTextColor = Color.FromHex("#2934D0");
                ButtonText = "unfollow";
            }
          

        }
    }
}
