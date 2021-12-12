using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.Models
{
    public class UserReport
    {
        public int UserReportId { get; set; }
        public string Text { get; set; }
        public int UserIdReported { get; set; }
        public int ReportedUserId { get; set; }

        public virtual User ReportedUser { get; set; }
        public virtual User UserIdReportedNavigation { get; set; }
    }
}
