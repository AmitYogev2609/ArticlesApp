using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArticlesApp.Models;
using ArticlesApp.ViewModels;
namespace ArticlesApp.Services
{
   public class SearchDataTemplateSelector:DataTemplateSelector
    {
        public DataTemplate ArticleDataTemp { get; set; }
        public DataTemplate UserDataTemp { get; set; }
        public DataTemplate InterestDataTemp { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is ArticleWithPicture)
                return ArticleDataTemp;
            if (item is UserWithPicture)
                return UserDataTemp;
            return InterestDataTemp;
        }
    }
}
