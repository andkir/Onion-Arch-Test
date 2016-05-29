using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Interfaces
{
    public interface IRepository<T>: IDisposable  where T  : class
    {
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
        void Add(T entity);
        void Commit();
    }
}
