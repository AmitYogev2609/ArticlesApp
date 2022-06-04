using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Views;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ArticlesApp.ViewModels
{
    public class ViewInterestsViewModel
    {
       public ObservableCollection<InterestViewModel> interests { get; set; }
        public Color diviedColor { get=>new Color(0, 0, 0, 0.1);  set { 
            } }
        public ViewInterestsViewModel(List<Interest> interestslst )
        {
            interests = new ObservableCollection<InterestViewModel>();
            foreach (var item in interestslst)
            {
                interests.Add(new InterestViewModel(item));
            }
        }
        public void update(List<Interest> interestslst)
        {
            interests.Clear();
            foreach (var item in interestslst)
            {
                interests.Add(new InterestViewModel(item));
            }
        }
       
    }
}
