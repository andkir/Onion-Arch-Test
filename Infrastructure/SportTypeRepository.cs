using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;
using Core.Interfaces;

namespace Infrastructure
{
    public class SportTypeRepository : ISportTypeRepository
    {
        private readonly BaseRepository<SportType> repository;  
        public SportTypeRepository(BaseRepository<SportType> repository)
        {
            this.repository = repository;
        }

        public SportType GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<SportType> Find(Expression<Func<SportType, bool>> predicate)
        {
            return repository.Find(predicate);
        }

        public IEnumerable<SportType> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(SportType entity)
        {
            repository.Update(entity);
        }

        public void Delete(SportType entity)
        {
            repository.Delete(entity);
        }

        public void Add(SportType entity)
        {
            repository.Add(entity);
        }

        public void Commit()
        {
            repository.Commit();
        }
        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
