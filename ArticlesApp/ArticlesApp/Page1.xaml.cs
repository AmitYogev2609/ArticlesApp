using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.Services;
using ArticlesApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.XForms.RichTextEditor;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;

namespace ArticlesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            //ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            //Task<List<Interest>> taskinterests = proxy.GetInitialInterests();
            //List<Interest> interests = taskinterests.Result;
            InitializeComponent();
            //test.ItemsSource = interests;
            this.BindingContext = new ViewModel();
        }

        private void save_Clicked(object sender, EventArgs e)
        {
            string htmltext = texteditor.HtmlText;
            Navigation.PushAsync(new WebViewTest(htmltext));
        }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand ImageCommand { get; set; }

        public ViewModel()
        {
           
            ImageCommand = new Command<object>(LoadImage);
        }

        

        void LoadImage(object obj)
        {
            ImageInsertedEventArgs imageInsertedEventArgs = (obj as ImageInsertedEventArgs);
            this.GetImage(imageInsertedEventArgs);
        }

        async void GetImage(ImageInsertedEventArgs imageInsertedEventArgs)
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "צלם תמונה"
            });
            using (Stream imageStream = await result.OpenReadAsync())
            {
                if (imageStream != null)
                {
                    Syncfusion.XForms.RichTextEditor.ImageSource imageSource = new Syncfusion.XForms.RichTextEditor.ImageSource();
                    imageSource.ImageStream = imageStream;
                    imageInsertedEventArgs.ImageSourceCollection.Add(imageSource);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}