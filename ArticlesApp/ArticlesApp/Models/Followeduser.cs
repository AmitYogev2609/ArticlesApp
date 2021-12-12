using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class Followeduser
    {
        public int UserId { get; set; }
        public int FollowingId { get; set; }

        public virtual User Following { get; set; }
        public virtual User User { get; set; }
    }
}
