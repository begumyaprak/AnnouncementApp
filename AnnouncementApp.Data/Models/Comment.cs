using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.Models
{
    public class Comment
    {

        public int Id { get; set; }

        public User User { get; set; }
        
        public string UserId { get; set; }

        public Announcement Announcement { get; set; }

        public int AnnouncementId { get; set; }

        public string CommentText { get; set; }
    }
}
