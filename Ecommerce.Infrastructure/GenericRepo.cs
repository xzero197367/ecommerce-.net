
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

        public async Task<T> create(T entity)
        {
            var createdEntity = await _context.AddAsync(entity);
            return createdEntity.Entity;
        }
        public async Task<T> update(T entity)
        {
            var updatedEntity = _context.Update(entity);
            return updatedEntity.Entity;
        }
        public async Task<T> delete(T entity)
        {
            var deletedEntity = _context.Remove(entity);
            return deletedEntity.Entity;
        }
        public async Task<IQueryable<T>> getAll()
        {
            return _dbSet.AsQueryable();
        }
        public async Task<T?> getById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task saveChanges()
        {
            await _context.SaveChangesAsync();

        }

  
    }

}
