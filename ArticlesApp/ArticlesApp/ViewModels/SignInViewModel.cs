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
    public class InterestWithColor: INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private Color backgroundColor;
        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                if (value != backgroundColor)
                {
                    backgroundColor = value;
                    OnPropertyChanged(nameof(BackgroundColor));

                }

            }
        }

        private Interest interest;
        public Interest Interest
        {
            get => interest;
            set
            {
                if (value != interest)
                {
                    interest = value;
                    OnPropertyChanged(nameof(Interest));

                }

            }
        }
        public InterestWithColor(Interest interest)
        {
            BackgroundColor = Color.White;
            this.Interest = interest;
        }
        public Interest GetInterest()
        {
            return  Interest;
        }
    }
    public class SignInViewModel : INotifyPropertyChanged
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
        #region Birth date
        private DateTime birthdate;
        public DateTime BirthDate
        {
            get => birthdate;
            set
            {
                if (value != birthdate)
                {
                    birthdate = value;
                    if (this.birthdateSet)
                        BirthDateTextColor = Color.Black;
                    this.birthdateSet = true;
                    OnPropertyChanged(nameof(BirthDate));

                }
            }
        }
        private bool is_birthdate_valid;
        public bool IsBirthDateValid
        {
            get => is_birthdate_valid; set
            {
                if (is_birthdate_valid != value)
                {
                    is_birthdate_valid = value;
                    OnPropertyChanged(nameof(IsBirthDateValid));
                }
            }
        }
        private string birthdateerror;
        public string BirthDateError
        {
            get => birthdateerror; set
            {
                if (birthdateerror != value)
                {
                    birthdateerror = value;
                    OnPropertyChanged(nameof(BirthDateError));
                }
            }
        }


        private Color birthdatebordercolor;
        public Color BirthDateBorderColor
        {
            get => birthdatebordercolor;
            set
            {
                if (birthdatebordercolor != value)
                {
                    birthdatebordercolor = value;
                    OnPropertyChanged(nameof(BirthDateBorderColor));
                }
            }
        }
        private Color textColor;
        public Color BirthDateTextColor
        {
            get => textColor;
            set
            {
                if (value != textColor)
                {
                    textColor = value;
                    OnPropertyChanged(nameof(BirthDateTextColor));
                }


            }
        }
        private bool birthdateSet;
        #endregion
        #region Password
        private string password;
        public string Password
        {
            get => password;
            set
            {
                if (value != password)
                {
                    password = value;
                    OnPropertyChanged(nameof(Password));
                    ValidatePassword();
                }
            }
        }
        private bool is_password_valid;
        public bool IsPasswordValid
        {
            get => is_password_valid;
            set
            {
                if (is_password_valid != value)
                {
                    is_password_valid = value;
                    OnPropertyChanged(nameof(IsPasswordValid));
                }

            }
        }
        private string passworderror;
        public string PasswordError
        {
            get => passworderror;
            set
            {
                if (passworderror != value)
                {
                    passworderror = value;
                    OnPropertyChanged(nameof(PasswordError));
                }
            }
        }
        private Color passwordbordercolor;
        public Color PasswordBorderColor
        {
            get => passwordbordercolor;
            set
            {
                if (passwordbordercolor != value)
                {
                    passwordbordercolor = value;
                    OnPropertyChanged(nameof(PasswordBorderColor));
                }
            }
        }
        #endregion
        public SignInViewModel()
        {
            this.birthdateSet = false;
            EmailBorderColor = new Color(0, 0, 0);
            IsEmailValid = true;
            EmailError = "  ";
            UserNameBorderColor = new Color(0, 0, 0);
            IsUserNameValid = true;
            UserNameError = " ";
            FullNameBorderColor = new Color(0, 0, 0);
            IsFullNameValid = true;
            FullNameError = " ";
            BirthDateBorderColor = new Color(0, 0, 0);
            IsBirthDateValid = true;
            BirthDateError = " ";
            BirthDateTextColor = new Color(0, 0, 0, 0.60);
            BirthDate = DateTime.Now;
            PasswordBorderColor = new Color(0, 0, 0);
            IsPasswordValid = true;
            PasswordError = " ";
        }
        public ObservableCollection<InterestWithColor> Interests;

        public void getInterest()
        {
            
            
            
            Interests = new ObservableCollection<InterestWithColor>();

            foreach (var item in ((App)App.Current).Interests)
            {
                if(item.IsMajor)
                { 
                    Interests.Add(new InterestWithColor(item));
                }
            }

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
        public void ValdateBirthdate()
        {
            IsBirthDateValid = true;
            if (BirthDate == default(DateTime))
            {
                this.BirthDateBorderColor = Color.Red;
                this.BirthDateError = "This is a mandatory field";
                this.IsBirthDateValid = false;
            }
            else if (BirthDate >= DateTime.Now)
            {
                this.BirthDateBorderColor = Color.Red;
                this.BirthDateError = "date must be earlier then today";
                this.IsBirthDateValid = false;
            }
            if (IsBirthDateValid)
            {
                this.BirthDateBorderColor = new Color(0, 0, 0);
                this.BirthDateError = " ";
            }
        }
        private void ValidatePassword()
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var input = Password;
            PasswordError = "";
            IsPasswordValid = true;
            if (string.IsNullOrWhiteSpace(input))
            {
                this.PasswordBorderColor = Color.Red;
                this.PasswordError = "Mamdatory field";
                this.IsPasswordValid = false;
                return;
            }

            if (!(input.Length >= 8 && input.Length <= 12))
            {
                PasswordError += "Password should not be less than 8 characters and greater than 12 characters. ";
                this.IsPasswordValid = this.IsPasswordValid && false;
                this.PasswordBorderColor = Color.Red;
                return;
            }
            if (!hasNumber.IsMatch(input))
            {
                PasswordError += "Password should contain At least one number. ";
                this.IsPasswordValid = this.IsPasswordValid && false;
                this.PasswordBorderColor = Color.Red;
                return;
            }
            if (!hasLowerChar.IsMatch(input))
            {
                PasswordError += "Password should contain At least one lower case letter. ";
                this.IsPasswordValid = this.IsPasswordValid && false;
                this.PasswordBorderColor = Color.Red;
                return;

            }
            if (input.Contains(" "))
            {
                PasswordError += "Password should not contain space. ";
                this.IsPasswordValid = this.IsPasswordValid && false;
                this.PasswordBorderColor = Color.Red;
                return;
            }
            if (!hasUpperChar.IsMatch(input))
            {
                PasswordError += "Password should contain At least one upper case letter.";
                this.IsPasswordValid = this.IsPasswordValid && false;
                this.PasswordBorderColor = Color.Red;
                return;
            }

            if (IsPasswordValid)
            {
                PasswordError = " ";
                this.PasswordBorderColor = new Color(0, 0, 0);
            }
        }
        private async Task<bool> EmailExist()
        {
            bool exists = await Proxy.EmailExists(Email);
            if (exists == true)
            {
                this.EmailBorderColor = Color.Red;
                this.EmailError = "Email address already exists";
                IsEmailValid = false;
                return false;
            }
            return true;
        }
        private async Task<bool> UserNameExist()
        {
            bool exists = await Proxy.UserNameExists(UserName);
            if (exists == true)
            {
                this.UserNameBorderColor = Color.Red;
                this.UserNameError = "User name already exists";
                IsUserNameValid = false;
                return false;
            }
            return true;
        }

        public ICommand MoveToAddImage => new Command(ToAddPictaure);
        public async void ToAddPictaure()
        {
            ValidateEmail();
            ValdateUserName();
            ValdateFullName();
            ValdateBirthdate();
            ValidatePassword();


            bool con = true;
            bool b = await UserNameExist();
            bool t = await EmailExist();
            con= b&& t;
            if (IsEmailValid && IsUserNameValid && IsFullNameValid && IsBirthDateValid && IsPasswordValid && con)
            {

                NavigateToPageEvent?.Invoke();
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
                imgSource =  ImageSource.FromStream(() => stream);
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
        public List<InterestWithColor> selected;
        public ICommand MovetoChoose => new Command(moveToChooseInterest);
        public  void moveToChooseInterest()
        {
            getInterest();
            NavigateToPageEvent?.Invoke();
          

        }

        public  void MovetoEditeimage()
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
            string str = FullName.Substring(lst+1);
            return str;
        }
        private string GetFirst()
        {
            int lst = FullName.IndexOf(' ');
            string str = FullName.Substring(0, lst);
            return str;
        }

        public async void MoveToSignUp(List<Interest> MyInterests)
        {
            User newUser = new User()
            {
                Email=this.Email,
                UserName=this.UserName,
                LastName= GetLast(),
                FirstName= GetFirst(),
                BirthDay=this.BirthDate,
                Pswd=this.Password,
                IsManger=false,

            };
            foreach (var item in MyInterests)
            {
                FollwedInterest follwedInterest = new FollwedInterest()
                {
                   
                    InterestId=item.InterestId
                };
                newUser.FollwedInterests.Add(follwedInterest);
            }
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
            if(file==null)
            {
                issucces = await Proxy.SignUP(newUser);
            }
            else
            {
                issucces = await Proxy.SignUp(newUser, file);
            }
            
           if(issucces)
            {
                finishsign();
            }
        }
        public async void finishsign()
        {
            LoadingPopUp popup = new LoadingPopUp();
            NavigateToLoading?.Invoke(popup);
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
           ((App)App.Current).User = await proxy.LoginAsync(Email, Password);
            popup.DismisPopUP();
            ((App)App.Current).MainPage = new NavigationPage(new TabbedMenu(email, password)) { BarTextColor= Color.Black,
            BarBackgroundColor=Color.White};

        }
    }
}
