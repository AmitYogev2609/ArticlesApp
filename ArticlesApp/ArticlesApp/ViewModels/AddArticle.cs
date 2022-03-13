using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ArticlesApp.Models;
namespace ArticlesApp.ViewModels
{
    public class AddArticle:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private string title;
        public string Title
        { 
            get=>title;
            set 
            {
                if(title != value)
                {
                    title = value;
                    OnPropertyChanged(nameof(Title));
                }
            } 
        }
        private string description;
        public string Description
        {
            get => description;
           set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public ObservableCollection<Interest> Interests { get; set; }
        public AddArticle()
        {
            Interests = new ObservableCollection<Interest>();
        }
    }
}
