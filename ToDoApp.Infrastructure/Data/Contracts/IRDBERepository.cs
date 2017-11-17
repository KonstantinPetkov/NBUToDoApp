using System.Linq;

namespace ToDoApp.Infrastructure.Data.Contracts
{
    public interface IRDBERepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllReadonly();

        void Detach(T entity);

        int SaveChanges();
    }
}
