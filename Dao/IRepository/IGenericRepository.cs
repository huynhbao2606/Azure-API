using AzureAPI.Entities;
using System.Linq.Expressions;

namespace AzureAPI.Dao.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetEntities(Expression<Func<T, bool>> filter,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy,
                string includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}
