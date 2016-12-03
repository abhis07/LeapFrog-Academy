using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.LFAForum.Repository
{
    public interface IRepository<T> where T:class
    {
        void Create(T entity);
        IQueryable<T> Read();
        void Update(T entity);
        void Delete(T entity);
    }
}
