using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public string Pswd { get; set; }
        public bool IsManger { get; set; }
       
    }
}
