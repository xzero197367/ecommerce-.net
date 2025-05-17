using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.GenericServices
{
    public interface IGenericService<NormalType, OriginType>
    {
        public Task<NormalType> GetByIdAsync(int id);
        public Task<List<NormalType>> GetAllAsync();
        public Task<List<NormalType>> GetWithConditionAsync(Expression<Func<OriginType, bool>> predicate);
        public Task<NormalType> AddAsync(NormalType entity);
        public Task<NormalType> UpdateAsync(NormalType entity);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> DeleteWithConditionAsync(Expression<Func<OriginType, bool>> predicate);
    }
}
