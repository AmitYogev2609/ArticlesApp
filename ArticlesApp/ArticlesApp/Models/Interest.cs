using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public  class Interest
    {
        public Interest()
        {
            ArticleInterestTypes = new List<ArticleInterestType>();
            FollwedInterests = new List<FollwedInterest>();
        }
      
        public int InterestId { get; set; }
        public string InterestName { get; set; }
        public bool IsMajor { get; set; }

        public virtual ICollection<ArticleInterestType> ArticleInterestTypes { get; set; }
        public virtual ICollection<FollwedInterest> FollwedInterests { get; set; }
        
    }
}
