
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.LFAForum.Repository
{
    public class Repository<C,T> : IRepository<T>
        where T : class
        where C : DbContext
    {

        public C Context { get { return db; } }
        private C db;
        
        public Repository(DbContext context)
        {
            db = (C)context;
        }

        public void Create(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<T> Read()
        {
            return db.Set<T>().AsQueryable();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
