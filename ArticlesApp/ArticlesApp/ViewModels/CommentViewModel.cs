using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using ArticlesApp.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;

namespace ArticlesApp.ViewModels
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private Comment comment;
        public Comment Comment { get=>comment; set
            {
                if(comment!=value)
                {
                    comment = value;
                    OnPropertyChanged(nameof(Comment));
                }
            }
        }
        private UserWithPicture user;
        public UserWithPicture User { get=>user; set
            {
                if(user!=value)
                {
                    user = value;
                    OnPropertyChanged(nameof(User));
                }
            } }
        public CommentViewModel(Comment com)
        {
            this.Comment = com;
            this.User = new UserWithPicture(com.User);
        }
    }
}
