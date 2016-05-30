using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Newtonsoft.Json;

namespace Infrastructure.Json
{
    public class SportComplexJsonRepository : ISportComplexRepository
    {
        public SportComplex GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportComplex> Find(Expression<Func<SportComplex, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SportComplex> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SportComplex entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SportComplex entity)
        {
            throw new NotImplementedException();
        }

        public void Add(SportComplex entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            File.WriteAllText(@"c:\SportComplexStorage.json", json);
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
