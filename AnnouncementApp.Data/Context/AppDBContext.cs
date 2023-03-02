using AnnouncementApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {

        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Announcement> Announcement { get; set; }

        public DbSet<Like> Like { get; set; }

        public DbSet<Comment> Comment { get; set; }




    }
}
