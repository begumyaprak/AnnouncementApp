using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementApp.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
    }

}
