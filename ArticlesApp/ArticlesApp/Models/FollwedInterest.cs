using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class FollwedInterest
    {
        public int UserId { get; set; }
        public int InterestId { get; set; }

        public virtual Interest Interest { get; set; }
        public virtual User User { get; set; }
    }
}
