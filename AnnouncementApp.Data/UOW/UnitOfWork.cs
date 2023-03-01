
using AnnouncementApp.Data.Models;
using AnnouncementApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbContext;
      
        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;

           // Users = new Repository<Users>(_dbContext);

            Announcements = new Repository<Announcements>(_dbContext);


        }

        //public IRepository<Users> Users { get; private set; }

        public IRepository<Announcements> Announcements { get; private set; }

      

   



        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
