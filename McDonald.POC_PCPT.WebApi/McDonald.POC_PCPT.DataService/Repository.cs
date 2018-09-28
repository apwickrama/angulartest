using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McDonald.POC_PCPT.DataService
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

        /// <summary>
        /// Add New object into spcific table
        /// </summary>
        /// <param name="newEntity"></param>
        public void Add(T newEntity)
        {
            dbSet.Add(newEntity);
        }

        /// <summary>
        /// Delete data from table
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            T exEntity = dbSet.Find(id);
            dbSet.Remove(exEntity);
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        /// <summary>
        /// Get all data from db
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> SelectAll()
        {
            return dbSet.ToList();
        }

        /// <summary>
        /// Get specic data from db using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T SelectById(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Update specific object into the table
        /// </summary>
        /// <param name="exEntity"></param>
        public void Update(T exEntity)
        {
            dbSet.Attach(exEntity);
            context.Entry(exEntity).State = EntityState.Modified;
        }
    }
}
