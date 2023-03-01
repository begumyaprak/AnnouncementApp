
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.Models
{
    public class Users : IdentityUser 
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Department { get; set; }

        //likes

        // comments

    }
}
