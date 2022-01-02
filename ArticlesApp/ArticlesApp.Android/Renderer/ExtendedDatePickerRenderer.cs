using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ArticlesApp.Droid;
using ArticlesApp.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ArticlesApp.Renderer.ExtendedDatePicker), typeof(ArticlesApp.Droid.Render.ExtendedDatePickerRenderer))]
namespace ArticlesApp.Droid.Render
{
    public class ExtendedDatePickerRenderer : DatePickerRenderer
    {

        public ExtendedDatePickerRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                this.Control.SetBackground(null);
                this.Control.Text = "Select birthdate";
            }
        }
    }
}