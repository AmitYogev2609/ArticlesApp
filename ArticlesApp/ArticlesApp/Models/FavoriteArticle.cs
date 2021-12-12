using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class FavoriteArticle
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
