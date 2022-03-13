using System;
using System.Collections.Generic;
using System.Text;
using ArticlesApp.Models;
using Xamarin;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
namespace ArticlesApp.ViewModels
{
    public class MainPageViewModel
    {
        public List<Article> Articles { get; set; }
        public Color diviedColor { get=>new Color(196, 196, 196, 0.29);  }
    }
}
