using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.Services;
//using ArticlesApp.Models;
using Xamarin.Essentials;
using System.Linq;

namespace ArticlesApp.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        #region refrence variables
        public Color border { get => new Color(0, 0, 0, 0.51); }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region main property
        private string email;
        public string Email { get=>email; set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            } }
        private string password;
        public string Password { get=>password; set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            } }
        #endregion
        public ICommand LogInCommand => new Command(onPress); 
        public async void onPress()
        {

        }
        public static void MoveToMainPge()
        { }
        public ICommand SignInCommand => new Command(MoveToSignIn);
        public Action<Page> NavigateToPageEvent;
        public void MoveToSignIn()
        {
            Page sign = new Page();
            NavigateToPageEvent?.Invoke(sign);
        }
      

    }
}
