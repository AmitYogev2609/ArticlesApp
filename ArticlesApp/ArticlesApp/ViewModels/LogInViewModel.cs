using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.Services;
using ArticlesApp.Models;
using ArticlesApp.Views;
using Xamarin.Essentials;
using System.Linq;


namespace ArticlesApp.ViewModels
{
    class LogInViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #region refrence variables
        public Color border { get=> new Color(0, 0, 0, 0.51); }
        #endregion
        #region Email 
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                { 
                    email = value;
                    OnPropertyChanged(nameof(Email));
                    if(email!=""||email!=null)
                    {
                        this.EmailBorderColor = new Color(0, 0, 0, 0.51);
                        this.IsEmailErorrVisible = false;
                    }
                }
            }
        }
        private string email;
        private Color emailbordercolor;
        public Color EmailBorderColor
        {
            get => emailbordercolor; 
            set
            {   if(emailbordercolor != value)
                {
                        emailbordercolor = value;
                        OnPropertyChanged(nameof(EmailBorderColor));
                }
            }
        }
        private bool is_email_erorr_visible;
        public bool IsEmailErorrVisible
        {
            get => is_email_erorr_visible; 
            set
            {
                if(is_email_erorr_visible != value)
                { 
                    is_email_erorr_visible = value;
                    OnPropertyChanged(nameof(IsEmailErorrVisible));
                }
            } 
        }
        #endregion

        #region Password
        public string Password
        {
            get => password;
            set
            {
                if(password != value)
                { 
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    if(password!="" || password != null)
                    {
                        this.PasswordBorderColor = new Color(0, 0, 0, 0.51);
                        this.IsPasswordErorrVisible = false;

                    }
                }
            } 
        }
        private string password;
        private Color passwordbordercolor;
        public Color PasswordBorderColor
        {
            get => passwordbordercolor;
            set
            {
                if( passwordbordercolor != value)
                { 
                    passwordbordercolor = value;
                    OnPropertyChanged(nameof(PasswordBorderColor));
                }
            }
        }
        private bool is_password_erorr_visible;
        public bool IsPasswordErorrVisible 
        {
            get => is_password_erorr_visible;
            set
            {
                if (is_password_erorr_visible != value)
                { 
                    is_password_erorr_visible= value;
                    OnPropertyChanged(nameof(IsPasswordErorrVisible));
                }
            }
        }
        #endregion

        public LogInViewModel()
        {
            this.EmailBorderColor = new Color(0, 0, 0);
            this.PasswordBorderColor = new Color(0, 0, 0);
            this.IsEmailErorrVisible = false;
            this.IsPasswordErorrVisible = false;
        }
        public ICommand LogInCommand => new Command(onPress);
        public Action<LoadingPopUp> NavigateToLoading;

        public async void onPress()
        {
            if (!Valid())
                return;
            LoadingPopUp popup = new LoadingPopUp();
            NavigateToLoading?.Invoke(popup);
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            ((App)App.Current).User = await proxy.LoginAsync(Email, Password);
            popup.DismisPopUP();
            //((App)App.Current).MainPage = new NavigationPage(new TabbedMenu(email, password));

            if (((App)App.Current).User == null)
            { 
                bool answer = await App.Current.MainPage.DisplayAlert("LogIn faild", "Email or password are wrong", "Try again", "create an acount");
                if (answer)
                {
                    this.PasswordBorderColor = Color.Red;
                    this.EmailBorderColor = Color.Red;
                    return;
                }
                else
                {
                    MoveToSignIn();
                }
            }
            else
            {
                ((App)App.Current).MainPage = new NavigationPage(new TabbedMenu(email, password) ) { BarBackgroundColor = Color.White };

            }
        }
        
        private bool Valid()
        {
            bool valid = true;
            if(Email==""||Email==null)
            {
                valid = false;
                this.IsEmailErorrVisible = true;
                this.EmailBorderColor = Color.Red;
            }
            if(Password==""||Password==null)
            {
                valid=false; 
                this.IsPasswordErorrVisible = true;
                this.PasswordBorderColor = Color.Red;
            }
            return valid;
        }
        public static void MoveToMainPge()
        { }
        public ICommand SignInCommand => new Command(MoveToSignIn);
        public ICommand ForgetPasswordCommand => new Command(MoveToForgetPassWord);

        public Action<Page> NavigateToPageEvent;
        public void MoveToSignIn()
        {
            Page sign = new SignIn();
           NavigateToPageEvent?.Invoke(sign);
        }
        public void MoveToForgetPassWord()
        {
            Page page = new ForgotPasswordEnterEmail();
            page.BindingContext = new ForgotPassWordViewModel()
            {
                Email = this.Email,
                
            };
            NavigateToPageEvent?.Invoke(page);
        }
      

    }
}
