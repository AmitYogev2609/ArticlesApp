using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectTypePopUp : Popup
    {
        public SelectTypePopUp(AddArticleViewModel context)
        {
            this.BindingContext = context;
            InitializeComponent();
        }
        private void PickImage(object sender, EventArgs e)
        {

            Dismiss("");

        }
    }
}