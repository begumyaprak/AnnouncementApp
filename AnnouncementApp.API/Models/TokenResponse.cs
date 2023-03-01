using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.API.Models
{
    public  class TokenResponse
    {

        [Display(Name = "Expire Time")]
        public int ExpireTime { get; set; }


        [Display(Name = "Access Token")]
        public string AccessToken { get; set; }


        public string Email { get; set; } 

    

    }
}
