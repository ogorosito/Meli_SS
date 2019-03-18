﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
      //IEnumerable<T> FindBy(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
