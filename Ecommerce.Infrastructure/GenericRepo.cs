
using System.Linq.Expressions;
using System.Windows;
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
            try
            {
                var createdEntity = await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return createdEntity.Entity;
            }
            catch(DbUpdateException ex)
            {
                throw new Exception($"Error creating entity, {ex.Message}", ex);
            }
        }
        public async Task<T> update(T entity)
        {
            var updatedEntity = _context.Update(entity);
            await _context.SaveChangesAsync();
            return updatedEntity.Entity;
        }
        public async Task<T> delete(T entity)
        {
            var deletedEntity = _context.Remove(entity);
            await _context.SaveChangesAsync();

            return deletedEntity.Entity;
        }
        public async Task<IQueryable<T>> getAll()
        {
            return _dbSet.AsQueryable();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
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