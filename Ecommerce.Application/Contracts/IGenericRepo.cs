using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
    public interface IGenericRepo<T>
    {
        public T create(T entity);
        public T update(T entity);
        public T delete(T entity);
        public T getById(int id);
        public IQueryable<T> GetAll();

        public void SaveChanges();
    }
}
