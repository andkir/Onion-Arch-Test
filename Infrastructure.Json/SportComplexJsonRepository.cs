using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Json
{
    public class SportComplexJsonRepository : ISportComplexRepository
    {
        private string filePath = @"c:\SportComplexStorage.json";

        public SportComplexJsonRepository()
        {
            if (!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
        }

        public SportComplex GetById(int id)
        {
            return GetAll().SingleOrDefault(x=>x.Id == id);
        }

        public IEnumerable<SportComplex> Find(Expression<Func<SportComplex, bool>> predicate)
        {
            return GetAll().Where(predicate.Compile());
        }

        public IEnumerable<SportComplex> GetAll()
        {
            var text = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<SportComplex>>(text) ?? new List<SportComplex>();
        }

        public void Update(SportComplex entity)
        {
            var sportTypes = GetAll().ToList();

            var item = sportTypes.SingleOrDefault(x=>x.Id == entity.Id);
            if (item != null)
            {
                item.Name = entity.Name;
            }

            string newList = JsonConvert.SerializeObject(sportTypes, Formatting.Indented);
            File.WriteAllText(filePath, newList);
        }

        public void Delete(SportComplex entity)
        {
            var sportTypes = GetAll().ToList();
            var toDelete = sportTypes.SingleOrDefault(x => x.Id == entity.Id);

            sportTypes.Remove(toDelete);
            string newList = JsonConvert.SerializeObject(sportTypes, Formatting.Indented);
            File.WriteAllText(filePath, newList);
        }

        public void Add(SportComplex entity)
        {
            var sportTypes = GetAll().ToList();

            sportTypes.Add(entity);
            string newList = JsonConvert.SerializeObject(sportTypes, Formatting.Indented);
            File.WriteAllText(filePath, newList);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
