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
        private ArticlesAPIProxy Proxy = ArticlesAPIProxy.CreateProxy();
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
                
            } }
        private bool isemailvalid;
        public bool IsEmailValid { get=>isemailvalid; set
            {
                if(isemailvalid!=value)
                {
                    isemailvalid = value;
                    OnPropertyChanged(nameof(IsEmailValid));
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
                    this.IsUserNameValid = false;
                }
            }
        }
        private bool is_username_valid;
        public bool IsUserNameValid
        {
            get => is_username_valid; set
            {
                if (is_username_valid != value)
                {
                    is_username_valid = value;
                    OnPropertyChanged(nameof(IsUserNameValid));
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
            IsEmailValid = true;
            EmailError = "  ";
            UserNameBorderColor = new Color(0, 0, 0);
            IsUserNameValid = true;
            UserNameError = " ";
            
        }
        public ICommand EmailComplete => new Command(ValidateEmail);
        public event EventHandler EmailConfirmed;
        public  void ValidateEmail()
        {
            if(Email==null||Email=="")
            {
                this.EmailError = "Mandatory field";
                IsEmailValid = false;
                this.EmailBorderColor = Color.Red;
            }
            else
            { 
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                if (email != addr.Address)
                {
                    EmailError = "Invalid email address";
                    this.EmailBorderColor = Color.Red;
                }
                IsEmailValid = addr.Address == Email;
            }
            catch
            {
                EmailError = "Invalid email address";
                IsEmailValid = false;
                this.EmailBorderColor = Color.Red;
            }
            }
            
            if(this.IsEmailValid)
            {
                this.EmailBorderColor = new Color(0, 0, 0);
                this.emailerror = " ";
            }
        }
        private async void exist()
        {
            bool exists = await Proxy.EmailExists(Email);
            if (exists == true)
            {
                this.EmailError = "Email address already exists";
                IsEmailValid = false;
            }
        }
        
    }
}
