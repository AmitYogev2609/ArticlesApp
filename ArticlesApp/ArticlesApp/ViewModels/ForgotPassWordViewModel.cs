using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using ArticlesApp.Services;
using ArticlesApp.Models;
using ArticlesApp.Views;
using Xamarin.Essentials;
using System.Linq;


namespace ArticlesApp.ViewModels
{
    public class ForgotPassWordViewModel
    {
        public string Email { get; set; }
        public Action<Page> NavigateToPageEvent;
        public int PaswordResetCode { get; set; }
        //chel if the email exicst in the server database if it is the server send back a password reset code and sends email to user
        public async void chekEmailAndGetCode()
        {

            if(true)
            {
                Page page = new Page();

            }

        }
    }
}
