using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.ViewModels;
using ArticlesApp.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace ArticlesApp.ViewModels
{
    class MyProfileViewModel
    {
        public UserWithPicture User { get; set; }
        public MyProfileViewModel(User user)
        {
            User = new UserWithPicture(user);
        }
        
    }
}
