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
using ArticlesApp.ViewModels;
using Xamarin.CommunityToolkit.Extensions;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddArticle : ContentPage
    {
        public AddArticle(AddArticleViewModel context)
        { try
            { 
            this.BindingContext = context;
                InitializeComponent();

                texteditor.Text += context.Description;
            context.navigateTopopUP = MoveToPopUp;
            using (context.MainImageStream )
            {
                if (context.MainImageStream != null)
                {
                    Syncfusion.XForms.RichTextEditor.ImageSource imageSource = new Syncfusion.XForms.RichTextEditor.ImageSource();
                    imageSource.ImageStream = context.MainImageStream;
                    imageSource.SaveOption = ImageSaveOption.Base64;
                    texteditor.InsertImage(imageSource);
                }
            }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void MoveToPopUp()
        {
            Navigation.ShowPopup(new AddImagePopUp(this.BindingContext));

        }
    }
}