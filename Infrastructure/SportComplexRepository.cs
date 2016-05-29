using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;
using Core.Interfaces;

namespace Infrastructure
{
    public class SportComplexRepository : ISportComplexRepository
    {
        private readonly BaseRepository<SportComplex> repository;  
        public SportComplexRepository(BaseRepository<SportComplex> repository)
        {
            this.repository = repository;
        }

        public SportComplex GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<SportComplex> Find(Expression<Func<SportComplex, bool>> predicate)
        {
            return repository.Find(predicate);
        }

        public IEnumerable<SportComplex> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(SportComplex entity)
        {
            repository.Update(entity);
        }

        public void Delete(SportComplex entity)
        {
            repository.Delete(entity);
        }

        public void Add(SportComplex entity)
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
