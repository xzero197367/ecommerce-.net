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
        Task<T> create(T entity);
        Task<T> update(T entity);
        Task<T> delete(T entity);

        Task<T?> getById(int id);
        Task<IQueryable<T>> getAll();
        Task saveChanges();
    }
}
