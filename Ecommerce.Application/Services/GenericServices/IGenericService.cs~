using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.GenericServices
{
    public interface IGenericService<NormalType, CreateType, OriginType>
    {
        public Task<NormalType> GetByIdAsync(int id);
        public Task<List<NormalType>> GetAllAsync();
        public Task<List<NormalType>> GetWithConditionAsync(Expression<Func<NormalType, bool>> predicate);
        public Task<NormalType> AddAsync(CreateType entity);
        public Task<NormalType> UpdateAsync(NormalType entity);
        public Task<bool> DeleteAsync(int id);
    }
}
