using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Linq;
using System.Text.RegularExpressions;
using ArticlesApp.Services;
using ArticlesApp.Models;
using ArticlesApp.Views;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using ArticlesApp.DTO;
using Xamarin.CommunityToolkit.Extensions;
using ArticlesApp.ViewModels;
using Xamarin.CommunityToolkit.UI.Views;

namespace ArticlesApp.ViewModels
{
    public class EditProfileViewModel:INotifyPropertyChanged
    {
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private ArticlesAPIProxy Proxy = ArticlesAPIProxy.CreateProxy();
        public Action NavigateToPageEvent;
        public Action NavigateToEditeImage;
        public Action<LoadingPopUp> NavigateToLoading;

        #region sign up
        public Color border { get => new Color(0, 0, 0, 0.51); }

        public Color bordercolor { get => new Color(0, 0, 0); }
        #region Email
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (value != email)
                {
                    email = value;
                    OnPropertyChanged(nameof(Email));

                }

            }
        }
        private bool isemailvalid;
        public bool IsEmailValid
        {
            get => isemailvalid; set
            {
                if (isemailvalid != value)
                {
                    isemailvalid = value;
                    OnPropertyChanged(nameof(IsEmailValid));
                }
            }
        }
        private string emailerror;
        public string EmailError
        {
            get => emailerror; set
            {
                if (emailerror != value)
                {
                    emailerror = value;
                    OnPropertyChanged(nameof(EmailError));
                }
            }
        }
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
        #region Full Name
        private string fullname;
        public string FullName
        {
            get => fullname;
            set
            {
                if (value != fullname)
                {
                    fullname = value;
                    OnPropertyChanged(nameof(FullName));
                }
                if (fullname != "" || fullname != null)
                {
                    this.FullNameBorderColor = new Color(0, 0, 0);
                    this.IsFullNameValid = false;
                }
            }
        }
        private bool is_fullname_valid;
        public bool IsFullNameValid
        {
            get => is_fullname_valid; set
            {
                if (is_fullname_valid != value)
                {
                    is_fullname_valid = value;
                    OnPropertyChanged(nameof(IsFullNameValid));
                }
            }
        }
        private string fullnameerror;
        public string FullNameError
        {
            get => fullnameerror; set
            {
                if (fullnameerror != value)
                {
                    fullnameerror = value;
                    OnPropertyChanged(nameof(FullNameError));
                }
            }
        }
        private Color fullnamebordercolor;
        public Color FullNameBorderColor
        {
            get => fullnamebordercolor;
            set
            {
                if (fullnamebordercolor != value)
                {
                    fullnamebordercolor = value;
                    OnPropertyChanged(nameof(FullNameBorderColor));
                }
            }
        }
        #endregion
        
        
        public EditProfileViewModel()
        {
            User user = ((App)App.Current).User;
            this.Email= user.Email;
            this.FullName = user.FirstName +" "+ user.LastName;
            this.UserName=user.UserName;
            EmailBorderColor = new Color(0, 0, 0);
            IsEmailValid = true;
            EmailError = "  ";
            UserNameBorderColor = new Color(0, 0, 0);
            IsUserNameValid = true;
            UserNameError = " ";
            FullNameBorderColor = new Color(0, 0, 0);
            IsFullNameValid = true;
            FullNameError = " ";
         
            
        }
       
        public void ValidateEmail()
        {
            IsEmailValid = true;
            if (Email == null || Email == "")
            {
                this.EmailError = "Mandatory field";
                IsEmailValid = false;
                this.EmailBorderColor = Color.Red;
            }
            else
            {
                try
                {
                    var regex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                    IsEmailValid = Regex.IsMatch(Email, regex, RegexOptions.IgnoreCase);


                    if (!IsEmailValid)
                    {
                        EmailError = "Invalid email address";
                        this.EmailBorderColor = Color.Red;
                    }
                }
                catch
                {
                    EmailError = "Invalid email address";
                    IsEmailValid = false;
                    this.EmailBorderColor = Color.Red;
                }
            }

            if (this.IsEmailValid)
            {
                this.EmailBorderColor = new Color(0, 0, 0);
                this.EmailError = " ";
            }
        }
        public void ValdateUserName()
        {
            IsUserNameValid = true;
            if (UserName == null || UserName == "")
            {
                this.UserNameError = "Mandatory field";
                IsUserNameValid = false;
                this.UserNameBorderColor = Color.Red;
            }
            if (this.IsUserNameValid)
            {
                this.UserNameBorderColor = new Color(0, 0, 0);
                this.UserNameError = " ";
            }
        }
        public void ValdateFullName()
        {
            IsFullNameValid = true;
            if (FullName == null || FullName == "")
            {
                this.FullNameError = "Mandatory field";
                IsFullNameValid = false;
                this.FullNameBorderColor = Color.Red;

            }
            else if (!this.FullName.Contains(" "))
            {

                this.FullNameError = "Must contain Fisrt Name and Last Name";
                IsFullNameValid = false;
                this.FullNameBorderColor = Color.Red;
            }
            if (IsFullNameValid)
            {
                this.FullNameBorderColor = new Color(0, 0, 0);
                this.FullNameError = " ";
            }
        }
        
        private async Task<bool> EmailExist()
        {
            User user = ((App)App.Current).User;
            if(this.Email!=user.Email)
            { 
            bool exists = await Proxy.EmailExists(Email);
            if (exists == true)
            {
                this.EmailBorderColor = Color.Red;
                this.EmailError = "Email address already exists";
                IsEmailValid = false;
                return false;
            }
            }
            return true;
        }
        private async Task<bool> UserNameExist()
        {
            User user = ((App)App.Current).User;
            if (this.UserName != user.UserName)
            {
                bool exists = await Proxy.UserNameExists(UserName);
                if (exists == true)
                {
                    this.UserNameBorderColor = Color.Red;
                    this.UserNameError = "User name already exists";
                    IsUserNameValid = false;
                    return false;
                }
            }
            return true;
        }
        public ICommand finishUptade => new Command(ToAddPictaure);
        public async void ToAddPictaure()
        {
            ValidateEmail();
            ValdateUserName();
            ValdateFullName();
           


            bool con = true;
            bool b = await UserNameExist();
            bool t = await EmailExist();
            con = b && t;
            if (IsEmailValid && IsUserNameValid && IsFullNameValid &&   con)
            {

                uptade();
            }
            else
            {
                return;
            }
        }
        #endregion
        FileResult imageFileResult;
        public ImageSource imgSource;
        public event Action<ImageSource> SetImageSourceEvent;
        public ICommand PickImageFromDeviceCommand => new Command(OnPickImage);
        public async void OnPickImage()
        {
            FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "בחר תמונה"
            });

            if (result != null)
            {
                this.imageFileResult = result;

                var stream = await result.OpenReadAsync();
                imgSource = ImageSource.FromStream(() => stream);
                MovetoEditeimage();

            }
        }

        ///The following command handle the take photo button
        public ICommand ImageFromCameraCommand => new Command(OnCameraImage);
        public async void OnCameraImage()
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "צלם תמונה"
            });

            if (result != null)
            {
                this.imageFileResult = result;
                var stream = await result.OpenReadAsync();
                imgSource = ImageSource.FromStream(() => stream);
                MovetoEditeimage();

            }
        }
        
        public void MovetoEditeimage()
        {

            NavigateToEditeImage?.Invoke();

            if (SetImageSourceEvent != null)
            {
                SetImageSourceEvent(imgSource);
            }

        }
        private string GetLast()
        {
            int lst = FullName.IndexOf(' ');
            string str = FullName.Substring(lst + 1);
            return str;
        }
        private string GetFirst()
        {
            int lst = FullName.IndexOf(' ');
            string str = FullName.Substring(0, lst);
            return str;
        }

        public async void uptade()
        {
            User user=((App)App.Current).User;
            user.Email = this.Email;
            user.UserName = this.UserName;
            user.FirstName=GetFirst();
            user.LastName=GetLast();
            User newUser = new User()
            {
                Email = this.Email,
                UserName = this.UserName,
                LastName = GetLast(),
                FirstName = GetFirst(),
                BirthDay = user.BirthDay,
                Pswd = user.Pswd,
                IsManger = user.IsManger,
                UserId = user.UserId,

            };
            FileInfo file;
            if (imageFileResult != null)
            {
                file = new FileInfo()
                {
                    Name = this.imageFileResult.FullPath
                };
            }
            else
                file = null;
            bool issucces;
            if (file == null)
            {
                issucces = await Proxy.UptadeDetails(newUser);
            }
            else
            {
                issucces = await Proxy.UptadeDetails(newUser, file);
            }

            if (issucces)
            {
                EmailBorderColor = Color.Green;
                UserNameBorderColor = Color.Green;
                FullNameBorderColor = Color.Green;
            }
        }
        public async void finishsign()
        {
            LoadingPopUp popup = new LoadingPopUp();
            NavigateToLoading?.Invoke(popup);
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            //((App)App.Current).User = await proxy.LoginAsync(Email, Password);
            popup.DismisPopUP();
           

        }
    }
}
