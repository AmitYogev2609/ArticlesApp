using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using ArticlesApp.Views;
using ArticlesApp.Services;
using Xamarin.CommunityToolkit.UI.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Essentials;
using System.Windows.Input;
using System.Threading.Tasks;
using Syncfusion.XForms.RichTextEditor;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using Xamarin.Forms.PlatformConfiguration;
using Spire.Pdf;
using ArticlesApp.DTO;
namespace ArticlesApp.ViewModels
{
    public class AddArticleViewModel:INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        
        public ObservableCollection<Interest> ChooseIntrest
        {
            get ;
            set;
        }
        public ObservableCollection<User> ChooseUser { get; set; }
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
        public Action NavigateToPageEvent;

        public ObservableCollection<Interest> Interests { get; set; }
        public AddArticleViewModel()
        {
            Interests = new ObservableCollection<Interest>();
            ImageCommand = new Command<object>(LoadImage);
            
            ChooseIntrest = new ObservableCollection<Interest>();
            ChooseUser = new ObservableCollection<User>();
            Proxy = ArticlesAPIProxy.CreateProxy();
        }
        public ICommand NavigateToPage => new Command(GoToPage);
        public void GoToPage()
        {
            NavigateToPageEvent?.Invoke();
        }
        public FileResult imageFileResult;
        ArticlesAPIProxy Proxy;
        public Xamarin.Forms.ImageSource imgSource1;
        public event Action<Xamarin.Forms.ImageSource> SetImageSourceEvent;
        public ICommand PickImageFromDeviceCommand => new Command(OnPickImage);
        public async void OnPickImage()
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "בחר תמונה"
            });

            if (result != null)
            {
                this.imageFileResult = result;

                var stream = await result.OpenReadAsync();
                imgSource1 = Xamarin.Forms.ImageSource.FromStream(() => stream);
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
                imgSource1 = Xamarin.Forms.ImageSource.FromStream(() => stream);
                MovetoEditeimage();

            }
        }
        public void MovetoEditeimage()
        {

            //NavigateToEditeImage?.Invoke();

            if (SetImageSourceEvent != null)
            {
                SetImageSourceEvent(imgSource1);
            }

        }

        //ADD Article
        
        public Action NaviagteToAddarticle;
        public ICommand ToWrite => new Command(toAddArti);
        public Stream MainImageStream;
        
        public async void toAddArti()
        {
            MainImageStream = await imageFileResult.OpenReadAsync();
            NaviagteToAddarticle?.Invoke();
        }
        private string text;
        public string Text
        {
            get=>text; 
            set
            {
                if(text!=value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }
        public string HtmlText;
        //add image to article
        public ICommand ImageCommand { get; set; }
        void LoadImage(object obj)
        {
            ImageInsertedEventArgs imageInsertedEventArgs = (obj as ImageInsertedEventArgs);
            this.GetImage(imageInsertedEventArgs);
        }
        
        async void GetImage(ImageInsertedEventArgs imageInsertedEventArgs)
        {
            //FileResult FileResult= await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            //{
            //    Title = "צלם תמונה"
            //});

            FileResult FileResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "בחר תמונה"
            });
            using (Stream imageStream = await FileResult.OpenReadAsync())
            {
                if (imageStream != null)
                {
                    Syncfusion.XForms.RichTextEditor.ImageSource imageSource = new Syncfusion.XForms.RichTextEditor.ImageSource();
                    imageSource.ImageStream = imageStream;
                    imageSource.SaveOption = ImageSaveOption.Base64;
                    imageInsertedEventArgs.ImageSourceCollection.Add(imageSource);
                }
            }
        }
        public ICommand ToUpload => new Command(navitoUpload);
        public Action NavigateToUpload;
        public void navitoUpload()
        {
            NavigateToUpload?.Invoke();
        }
        public Command PickPDFCommand => new Command(ClickedOnPDF); //User chose to upload pdf files.
        private async void ClickedOnPDF() //Work in progress
        {
            try
            {
                var pickResult = await FilePicker.PickMultipleAsync(new PickOptions() //Maybe only let user pick one? WORK IN PROGRESS.
                {
                    FileTypes = FilePickerFileType.Pdf,
                    PickerTitle = "Pick PDF"
                }); ;

                if (pickResult != null)
                {


                    var pdfresultFile = pickResult.First();
                    PdfDocument pdf = new PdfDocument();
                   
                    pdf.LoadFromFile(pdfresultFile.FullPath);
                    MemoryStream stream = new MemoryStream();
                    
                    pdf.SaveToStream(stream, FileFormat.HTML);
                    if(stream.Length==0)
                    {

                    }
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    reader.BaseStream.Position = 0;
                    string html = reader.ReadToEnd();

                    HtmlText = html;
                    navtoahow?.Invoke();
                }
            }

            catch(Exception e) //User opted out or something went wrong
            {
                Console.WriteLine(e.Message);
            }
           
        }
        public Action navtoahow;
        public ICommand Upload => new Command(upload);
       public async void upload()
        {
            LoadingPopUp pop=new LoadingPopUp();
            navtopop?.Invoke(pop);
            Article article = new Article()
            {
                ArticleName = this.title,
                HtmlText=this.HtmlText,
                Description=this.Description,
                PublishDate= DateTime.Now
            };
            foreach (var item in ChooseIntrest)
            {
                ArticleInterestType articleInterestType = new ArticleInterestType()
                {
                    InterestId = item.InterestId
                };
                article.ArticleInterestTypes.Add(articleInterestType);
                Interest interest = ((App)App.Current).Interests.Find(u=>u.InterestId==item.InterestId);
                interest.ArticleInterestTypes.Add(articleInterestType);
            }
            foreach (var item in ChooseUser)
            {
                AuthorsArticle authorsArticle = new AuthorsArticle()
                {
                    UserId=item.UserId
                };
                article.AuthorsArticles.Add(authorsArticle);
            }
            if(ChooseUser.Any(u=>u.UserId!= ((App)App.Current).User.UserId)||ChooseUser.Count==0)
            { 
            AuthorsArticle authorsArticle1 = new AuthorsArticle()
            {
                UserId = ((App)App.Current).User.UserId
            };
                article.AuthorsArticles.Add(authorsArticle1);
            }
            ArticlesApp.DTO.FileInfo file = new DTO.FileInfo()
            {
                Name = imageFileResult.FullPath
            };
            bool succes = await Proxy.UploadArticle(article, file);
            if(succes)
            {
                bool num= await getUptadetData();
                pop.DismisPopUP();
                finish?.Invoke();
            }
            else
            {
                pop.DismisPopUP();
            }
        }
        public Action finish;
        public Action<LoadingPopUp> navtopop;
        public async Task<bool> getUptadetData()
        {

            try
            {
                List<Interest> list = new List<Interest>();
                ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
                list = await proxy.GetInterests();
                ((App)App.Current).Interests = list;
                
                try
                {
                    foreach (Interest interest in list)
                        foreach (ArticleInterestType type in interest.ArticleInterestTypes)
                        {
                            if (!((App)App.Current).Articles.Contains(type.Article))
                                ((App)App.Current).Articles.Add(type.Article);

                        }
                    foreach (Interest interest1 in list)
                        foreach (FollwedInterest follwed in interest1.FollwedInterests)
                        {
                            if (!((App)App.Current).Users.Contains(follwed.User))
                                ((App)App.Current).Users.Add(follwed.User);

                        }
                    ((App)App.Current).User = await proxy.LogInWithoutSession(((App)App.Current).User.Email, ((App)App.Current).User.Pswd);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }

}

