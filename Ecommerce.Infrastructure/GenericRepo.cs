
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

        public T create(T entity)
        {
            return _context.Add(entity).Entity;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public T update(T entity)
        {
            return _context.Update(entity).Entity;
        }
        public T delete(T entity)
        {
            return _context.Remove(entity).Entity;
        }
        public IQueryable<T> getAll()
        {
            return _dbSet;
        }
        public T? getById(int id)
        {
            return _dbSet.Find(id);
        }

        public void saveChanges()
        {
            _context.SaveChanges();

        }


    }

}
