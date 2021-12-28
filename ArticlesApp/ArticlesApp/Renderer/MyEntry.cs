using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArticlesApp.Renderer
{
    public class MyEntry : Entry
    {
        public static readonly BindableProperty FontProperty =
            BindableProperty.Create("Font", typeof(Font),
            typeof(MyEntry), new Font());
        
        public Font Font
        {
            get { return (Font)GetValue(FontProperty); }
            set { SetValue(FontProperty, value); }
        }
    }
}
