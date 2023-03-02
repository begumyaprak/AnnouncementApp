
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

            Like = new Repository<Like>(_dbContext);

            Comment = new Repository<Comment>(_dbContext);

            Announcement = new Repository<Announcement>(_dbContext);


        }

        public IRepository<Like> Like { get; private set; }
        public IRepository<Comment> Comment { get; private set; }

        public IRepository<Announcement> Announcement { get; private set; }

     
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
