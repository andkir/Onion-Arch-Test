using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core;
using Core.Interfaces;

namespace Infrastructure
{
    public class UserRepository: IUserRepository
    {
        private readonly BaseRepository<User> repository;  
        public UserRepository(BaseRepository<User> repository)
        {
            this.repository = repository;
        }

        public User GetById(int id)
        {
            return repository.GetById(id);
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return repository.Find(predicate);
        }

        public IEnumerable<User> GetAll()
        {
            return repository.GetAll();
        }

        public void Update(User entity)
        {
            repository.Update(entity);
        }

        public void Delete(User entity)
        {
            repository.Delete(entity);
        }

        public void Add(User entity)
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
