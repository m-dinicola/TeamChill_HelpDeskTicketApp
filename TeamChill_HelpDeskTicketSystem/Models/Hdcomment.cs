using System;
using System.Collections.Generic;

#nullable disable

namespace TeamChill_HelpDeskTicketSystem.Models
{
    public partial class Hdcomment
    {
        public int CommentId { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string Body { get; set; }
        public string UserEmail { get; set; }
        public int TicketId { get; set; }

        public virtual Hdticket Ticket { get; set; }
        public virtual UserTable UserEmailNavigation { get; set; }
    }
}
