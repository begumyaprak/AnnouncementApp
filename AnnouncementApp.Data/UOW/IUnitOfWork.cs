
using AnnouncementApp.Data.Models;
using AnnouncementApp.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnnouncementApp.Data.UOW
{

    public interface IUnitOfWork : IDisposable
    {
        public IRepository<Like> Like { get; }

        public IRepository<Comment> Comment { get; }

        public IRepository<Announcement> Announcement { get; }

        Task SaveChangesAsync();

        public void Dispose();
    }

    

}
