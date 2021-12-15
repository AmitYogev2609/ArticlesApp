using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.Services;
using ArticlesApp.Models;
using Xamarin.Essentials;
using System.Linq;

namespace ArticlesApp.ViewModels
{
    public class SignInViewModel: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public Color bordercolor { get=> new Color(0, 0, 0);  }
        #region Email
        private string email;
        public string Email { get=>email; 
            set
            {
                if(value!=email)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));
                }
                if (email != "" || email != null)
                {
                    this.EmailBorderColor = new Color(0, 0, 0);
                    this.showerror = false;
                }
            } }
        private bool showerror;
        public bool ShowError { get=>showerror; set
            {
                if(showerror!=value)
                {
                    showerror = value;
                    OnPropertyChanged(nameof(ShowError));
                }
            } }
        private string emailerror;
        public string EmailError { get=>emailerror; set
            { 
                if(emailerror!=value)
                {
                    emailerror = value;
                    OnPropertyChanged(nameof(EmailError));
                }
            } }
        private Color emailbordercolor;
        public Color EmailBorderColor
        {
            get => emailbordercolor;
            set
            {
                if (emailbordercolor != value)
                {
                    emailbordercolor = value;
                    OnPropertyChanged(nameof(EmailBorderColor));
                }
            }
        }
        #endregion
        #region user name
        private string username;
        public string UserName
        {
            get => username;
            set
            {
                if (value != username)
                {
                    username = value;
                    OnPropertyChanged(nameof(UserName));
                }
                if (username != "" || username != null)
                {
                    this.UserNameBorderColor = new Color(0, 0, 0);
                    this.ShowErrorUserName = false;
                }
            }
        }
        private bool showerrorusername;
        public bool ShowErrorUserName
        {
            get => showerrorusername; set
            {
                if (showerrorusername != value)
                {
                    showerrorusername = value;
                    OnPropertyChanged(nameof(ShowErrorUserName));
                }
            }
        }
        private string usernameerror;
        public string UserNameError
        {
            get => usernameerror; set
            {
                if (usernameerror != value)
                {
                    usernameerror = value;
                    OnPropertyChanged(nameof(UserNameError));
                }
            }
        }
        private Color usernamebordercolor;
        public Color UserNameBorderColor
        {
            get => usernamebordercolor;
            set
            {
                if (usernamebordercolor != value)
                {
                    usernamebordercolor = value;
                    OnPropertyChanged(nameof(UserNameBorderColor));
                }
            }
        }
        #endregion
        public SignInViewModel()
        {
            EmailBorderColor = new Color(0, 0, 0);
            ShowError = true;
            EmailError = "  ";
            UserNameBorderColor = new Color(0, 0, 0);
            ShowErrorUserName = true;
            UserNameError = " ";
        }
    }
}
