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
        private string resetcode; 
        public Action<Page> NavigateToPageEvent;
        public int PaswordResetCode { get; set; }
        //chel if the email exicst in the server database if it is the server send back a password reset code and sends email to user
        public async void chekEmailAndGetCode()
        {
            ArticlesAPIProxy proxy = ArticlesAPIProxy.CreateProxy();
            resetcode = await proxy.GetPasswordResetCode(this.Email);
            if(true)
            {
                Page page = new Page();

            }

        }
    }
}
