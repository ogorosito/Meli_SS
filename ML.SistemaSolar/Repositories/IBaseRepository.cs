using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
