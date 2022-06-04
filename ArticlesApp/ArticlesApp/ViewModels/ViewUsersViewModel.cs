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
    public class ViewUsersViewModel
    {
        public ObservableCollection<UserViewModel> Users { get; set; }
        public Color diviedColor
        {
            get => new Color(0, 0, 0, 0.1); set
            {
            }
        }
        public ViewUsersViewModel(List<User> users)
        {
            Users = new ObservableCollection<UserViewModel>();
            foreach (var item in users)
            {
                Users.Add(new UserViewModel(item));
            }
        }
        

    }
}

