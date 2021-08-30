using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace TeamChill_HelpDeskTicketSystem.Models
{
    public partial class Hdticket
    {
        public Hdticket()
        {
            Bookmarks = new HashSet<Bookmark>();
            Hdcomments = new HashSet<Hdcomment>();
        }

        public int TicketId { get; set; }
        public DateTime OpenDateTime { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Department { get; set; }
        public bool Complete { get; set; }
        public string UserEmail { get; set; }

        public virtual UserTable UserEmailNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Bookmark> Bookmarks { get; set; }
        [JsonIgnore]
        public virtual ICollection<Hdcomment> Hdcomments { get; set; }
    }
}
