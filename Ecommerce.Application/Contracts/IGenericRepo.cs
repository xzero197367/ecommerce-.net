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
        T create(T entity);

        Task<T> CreateAsync(T entity);
        Task SaveChangesAsync();

        T update(T entity);
        T delete(T entity);

        T getById(int id);
        IQueryable<T> getAll();
       void saveChanges();
    }
}
