using ML.SistemaSolar.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ML.SistemaSolar.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected CondicionClimaticaContext RepositoryContext { get; set; }

        public BaseRepository(CondicionClimaticaContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>();
        }

        //public IEnumerable<T> FindBy(Expression<Func<T, bool>> expression)
        //{
        //    return this.RepositoryContext.Set<T>().Where( Where(expression);
        //}

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            this.RepositoryContext.SaveChanges();
        }
    }
}
