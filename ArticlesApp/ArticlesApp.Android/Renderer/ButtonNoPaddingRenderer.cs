using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ArticlesApp.Renderer;


[assembly: ExportRenderer(typeof(ArticlesApp.Renderer.ButtonNoPadding), typeof(ArticlesApp.Droid.CustomRenderers.ButtonNoPaddingRenderer))]
namespace ArticlesApp.Droid.CustomRenderers
{
    public class ButtonNoPaddingRenderer : ButtonRenderer
    {
        public ButtonNoPaddingRenderer(Context context) : base(context) { }
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (ButtonNoPadding)this.Element;
            var nativeButton = (global::Android.Widget.Button)this.Control;
            nativeButton.SetPadding((int)view.Padding.Left, (int)view.Padding.Top, (int)view.Padding.Right, (int)view.Padding.Bottom);
        }
    }
}