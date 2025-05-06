
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class GenericRepo<T>  : IGenericRepo<T> where T : class
    {
        private readonly ContextDB _context;

        private readonly DbSet<T> _dbSet;
        public GenericRepo(ContextDB context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public T update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public T delete(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public T? getById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
