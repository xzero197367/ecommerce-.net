
using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure
{
    public class GenericRepo<T>  : IGenericRepo<T> where T : class
    {
        private readonly ContextDB _context;

        public readonly DbSet<T> _dbSet;
        public GenericRepo(ContextDB context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity).Entity;
        }

        public T? GetById(int id)
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
