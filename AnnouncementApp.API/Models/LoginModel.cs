using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.API.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email Adress")]
        public string Email { get; set; }

        [Required]
        //[MinLength(8)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
