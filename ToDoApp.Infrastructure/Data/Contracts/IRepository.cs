using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.Infrastructure.Data.Contracts
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void AddRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entity);

        void Delete(object id);

        void Delete(T entity);
    }
}
