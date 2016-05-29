using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core.Interfaces;

namespace Infrastructure
{
    public class BaseRepository<T> : IRepository<T> where T:class
    {
        private readonly SportDBContext context;
        private readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            context = new SportDBContext();
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
