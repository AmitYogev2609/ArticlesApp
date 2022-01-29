using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfImageEditor.XForms;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CropImage : ContentPage
    {
        //public CropImage(SignInViewModel context)
        //{
        //    InitializeComponent();
        //    this.BindingContext = (object)context;
        //    editor.Source = context.imgSource;
        //    Thread.Sleep(800);
        //    editor.SetToolbarItemVisibility("Text, Shape, Brightness, Effects, Bradley Hand, Path, 3:1, 3:2, 4:3, 5:4, 16:9, Undo, Redo, Transform", false);
        //    editor.ToolbarSettings.ToolbarItems.Add(new FooterToolbarItem() { Text = "Crop" });
        //    editor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;
        //}
        public CropImage()
        {
            InitializeComponent();
            
      
            editor.SetToolbarItemVisibility("Text, Shape, Brightness, Effects, Bradley Hand, Path, 3:1, 3:2, 4:3, 5:4, 16:9, Undo, Redo, Transform", false);
            editor.ToolbarSettings.ToolbarItems.Add(new FooterToolbarItem() { Text = "Crop" });
            editor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;
        }
        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            if (e.ToolbarItem.Text == "Crop")
            {
                var size = editor.ActualImageRenderedBounds;
                var minSize = Math.Min(size.Width, size.Height);
                var leftX = (size.Width - minSize) / 2;
                var topY = (size.Height - minSize) / 2;

                var x = (leftX * 100) / size.Width;
                var y = (topY * 100) / size.Height;
                var width = (minSize * 100) / size.Width;
                var height = (minSize * 100) / size.Height;

               editor.ToggleCropping(new Rectangle(x, y, width, height), true);
            }
        }
    }
}