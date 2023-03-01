
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace AnnouncementApp.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDBContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDBContext dbContext )
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            
            return _dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return  _dbSet.ToList();
        }

        public void Add(TEntity entity)
        {
            
             _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
             _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
           _dbContext.SaveChanges();
        }



        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            return _dbContext.Set<TEntity>().Where(where).AsQueryable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dbContext.Set<TEntity>().Where(expression).ToList();
        }
    }

}
