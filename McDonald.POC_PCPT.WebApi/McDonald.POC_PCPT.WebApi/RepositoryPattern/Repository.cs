using McDonald.POC_PCPT.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.WebApi.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PCPTDataContext context;
        protected DbSet<T> dbSet { get; set; }

        public Repository(PCPTDataContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }


        public void Add(T newEntity)
        {
            dbSet.Add(newEntity);
        }

        public void Delete(object id)
        {
            T exEntity = dbSet.Find(id);
            dbSet.Remove(exEntity);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return dbSet.ToList();
        }

        public T SelectById(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(T exEntity)
        {
            dbSet.Attach(exEntity);
            context.Entry(exEntity).State = EntityState.Modified;
        }
    }
}
