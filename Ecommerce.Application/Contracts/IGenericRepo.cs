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
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        T? GetById(int id);
        IQueryable<T> GetAll();
        void SaveChanges();
    }
}
