using System;
using System.Collections.Generic;

#nullable disable

namespace TeamChill_HelpDeskTicketSystem.Models
{
    public partial class Bookmark
    {
        public int BookmarkId { get; set; }
        public int TicketId { get; set; }
        public string UserEmail { get; set; }

        public virtual Hdticket Ticket { get; set; }
        public virtual UserTable UserEmailNavigation { get; set; }
    }
}
