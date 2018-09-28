using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.RepositoryPattern
{
    public interface IRepository<T> where T : class
    {
        void Add(T newEntity);
        IEnumerable<T> SelectAll();
        T SelectById(object id);
        void Update(T exEntity);
        void Delete(object id);
        void Save();
    }
}
