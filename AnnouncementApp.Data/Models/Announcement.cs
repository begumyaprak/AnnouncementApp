using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.Models
{
    public class Announcement
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string DetailInfo { get; set; }

        public List<Like> Likes { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
