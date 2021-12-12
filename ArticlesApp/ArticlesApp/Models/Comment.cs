using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class Comment
    {
        public int ComentId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }
}
