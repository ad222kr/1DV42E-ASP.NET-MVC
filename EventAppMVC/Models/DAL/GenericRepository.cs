using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EventAppMVC.Models.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal EventAppContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(EventAppContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach(var includeProperty in includeProperties.Split
                (new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity toDelete = _dbSet.Find(id);
            Delete(toDelete);
        }

        public virtual void Delete(TEntity toDelete)
        {
            if (_context.Entry(toDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(toDelete);
            }
            _dbSet.Remove(toDelete);
        }

        public virtual void Update(TEntity toUpdate)
        {
            _dbSet.Attach(toUpdate);
            _context.Entry(toUpdate).State = EntityState.Modified;
        }
    }
}