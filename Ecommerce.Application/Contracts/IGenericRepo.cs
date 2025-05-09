using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
    public interface IGenericRepo<T>
    {
        public T Create(T entity);
        public T Update(T entity);
        public T Delete(T entity);
        public T GetById(int id);
        public IQueryable<T> GetAll();

        public void SaveChanges();
    }
}
