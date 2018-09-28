using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.DataService
{
    public interface IRepository<T> where T : class
    {

        // abstract method signatures of CRUD functions 
        void Add(T newEntity);
        IEnumerable<T> SelectAll();
        T SelectById(object id);
        void Update(T exEntity);
        void Delete(object id);
        void Save();
    }
}
