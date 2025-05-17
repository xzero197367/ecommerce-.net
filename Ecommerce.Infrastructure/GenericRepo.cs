
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

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found");
                }
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error retrieving entity, {ex.Message}", ex);
            }
        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> GetWithConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                var createdEntity = await _dbSet.AddAsync(entity);
                createdEntity.State = EntityState.Added; // Set the state to Added
                await _context.SaveChangesAsync();
                createdEntity.State = EntityState.Detached; // Detach the entity from the context
                return createdEntity.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error adding entity, {ex.Message}", ex);
            }
        }

        public async Task<bool> DeleteWithConditionAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var entities = _dbSet.Where(predicate);
                if (!entities.Any())
                {
                    throw new Exception($"No entities found matching the condition");
                }
                _dbSet.RemoveRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error deleting entities, {ex.Message}", ex);
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var updatedEntity = _dbSet.Update(entity);
                updatedEntity.State = EntityState.Modified; // Set the state to Modified
                await _context.SaveChangesAsync();
                updatedEntity.State = EntityState.Detached; // Detach the entity from the context
             
                return updatedEntity.Entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error updating entity, {ex.Message}", ex);
            }
        }

        public async Task<bool> UpdateRangeAsync(List<T> entities)
        {
            try
            {
                 _dbSet.UpdateRange(entities);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error updating entity, {ex.Message}", ex);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error saving changes, {ex.Message}", ex);
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Entity with id {id} not found");
                }
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error deleting entity, {ex.Message}", ex);
            }
        }



    }

}