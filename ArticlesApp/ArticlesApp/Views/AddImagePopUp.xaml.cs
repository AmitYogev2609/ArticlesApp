using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticlesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;

namespace ArticlesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddImagePopUp : Popup
    {
        public AddImagePopUp(object context)
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