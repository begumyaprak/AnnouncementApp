
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.Models
{
    public class User : IdentityUser 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }

        public IEnumerable<Like> Likes { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}
