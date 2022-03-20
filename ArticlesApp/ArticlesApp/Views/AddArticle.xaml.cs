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
        { 
            

                this.BindingContext = context;
                InitializeComponent();
                byte[] imgbyt = File.ReadAllBytes(context.imageFileResult.FullPath);
                string base64img = Convert.ToBase64String(imgbyt);


                double with = App.Current.MainPage.Width;
            double w = page1.Height;
            double height = App.Current.MainPage.Height;
            
                if (texteditor.Text == null || texteditor.Text == "")
                {
                    texteditor.Text = $@"{context.Description}
            <p><img src =""data:image/png;base64,{base64img}"" Width=""{with - 30}"" height=""250""/></p>";
                }
                
                
            AbsoluteLayout.SetLayoutBounds(texteditor, new Rectangle(0, 0, App.Current.MainPage.Width, App.Current.MainPage.Height-60));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ((AddArticleViewModel)this.BindingContext).HtmlText = texteditor.HtmlText;
            Page page = new showBeforeUpload((AddArticleViewModel)this.BindingContext);
            Navigation.PushAsync(page);
        }
    }
}