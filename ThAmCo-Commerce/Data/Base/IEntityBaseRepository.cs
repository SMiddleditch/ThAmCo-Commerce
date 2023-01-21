using System.Linq.Expressions;
using ThAmCo_Commerce.Models;

namespace ThAmCo_Commerce.Data.Base
{
    public interface IEntityBaseRepository<X> where X : class, IEntityBase, new()
    {
            Task<IEnumerable<X>> GetAllAsync();
            Task<IEnumerable<X>> GetAllAsync(params Expression<Func<X, object>>[] includeProperties);
            Task<X> GetByIdAsync(int id);
            Task<X> GetByIdAsync(int id, params Expression<Func<X, object>>[] includeProperties);
            Task AddAsync(X entity);
            Task UpdateAsync(int id, X entity);
            Task DeleteAsync(int id);
        }
    }
