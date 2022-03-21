﻿using System;
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

        }
        public ICommand NavigateToPage => new Command(GoToPage);
        public void GoToPage()
        {
            NavigateToPageEvent?.Invoke();
        }
        public FileResult imageFileResult;
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
       



    }

}

