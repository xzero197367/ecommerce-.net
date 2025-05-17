using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
    public interface IGenericRepo<T>
    {
        public Task<T> GetByIdAsync(int id) ;
        public IQueryable<T> GetAllAsync() ;
        public IQueryable<T> GetWithConditionAsync(Expression<Func<T, bool>> predicate) ;
        public Task<T> AddAsync(T entity) ;
        public Task<T> UpdateAsync(T entity) ;
        public Task<bool> DeleteAsync(int id) ;
        public Task<bool> SaveChangesAsync();
        public Task<bool> DeleteWithConditionAsync(Expression<Func<T, bool>> predicate);
        public Task<bool> UpdateRangeAsync(List<T> entities);
    }
}
