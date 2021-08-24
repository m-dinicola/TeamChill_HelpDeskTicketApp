using System;
using System.Collections.Generic;

#nullable disable

namespace TeamChill_HelpDeskTicketSystem.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            Bookmarks = new HashSet<Bookmark>();
            Hdcomments = new HashSet<Hdcomment>();
            Hdtickets = new HashSet<Hdticket>();
        }

        public string UserEmail { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        public virtual ICollection<Hdcomment> Hdcomments { get; set; }
        public virtual ICollection<Hdticket> Hdtickets { get; set; }
    }
}
