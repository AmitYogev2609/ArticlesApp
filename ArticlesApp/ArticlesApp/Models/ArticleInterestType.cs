using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public  class ArticleInterestType
    {
        public int ArticleId { get; set; }
        public int InterestId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
