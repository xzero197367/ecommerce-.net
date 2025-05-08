
using System.Linq.Expressions;
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

        public T Create(T entity)
        {
            var createdEntity = _dbSet.Add(entity).Entity;
            return createdEntity;
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
            return _dbSet.AsQueryable();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
