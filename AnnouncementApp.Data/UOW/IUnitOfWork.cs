
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
        public IRepository<Users> Users { get; }

        public IRepository<Announcements> Announcements { get; }

        Task SaveChangesAsync();

        public void Dispose();
    }

    

}
