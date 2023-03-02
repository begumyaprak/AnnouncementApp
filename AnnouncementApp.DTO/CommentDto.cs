using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.DTO
{
    public class CommentDto
    {
    
        public string UserId { get; set; }

        public int AnnouncementId { get; set; }

        public string CommentText { get; set; }
    }
}
