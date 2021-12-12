using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class AuthorsArticle
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
