using Ecommerce.Application.Contracts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.GenericServices
{
    public class GenericServices<NormalType, OriginType>: IGenericService<NormalType, OriginType>
    where NormalType : class
    where OriginType : class
    {
        private readonly IGenericRepo<OriginType> genericRepo;

        public GenericServices(IGenericRepo<OriginType> genericRepo)
        {
            this.genericRepo = genericRepo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await genericRepo.GetByIdAsync(id);

            if (item == null)
                return false;
            await genericRepo.DeleteAsync(id);
            return await genericRepo.SaveChangesAsync();
        }
        public virtual async Task<List<NormalType>> GetAllAsync()
        {
            try
            {
                var items = await genericRepo.GetAllAsync()
                    .AsNoTracking()
                    .ToListAsync();
                if (items == null)
                    return null;
                return items.Adapt<List<NormalType>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting all items", ex);
            }
        }
        public virtual async Task<List<NormalType>> GetWithConditionAsync(Expression<Func<OriginType, bool>> predicate)
        {
            try
            {

                var items = await genericRepo.GetWithConditionAsync(predicate)
                    .AsNoTracking()
                    .ToListAsync();
                return items.Adapt<List<NormalType>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting items with condition", ex);
            }
        }

        public async Task<bool> DeleteWithConditionAsync(Expression<Func<OriginType, bool>> predicate)
        {
            try
            {
                await genericRepo.DeleteWithConditionAsync(predicate);
                return await genericRepo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while deleting item with condition", ex);
            }
        }
        public async Task<NormalType> GetByIdAsync(int id)
        {
            try
            {
                var item = await genericRepo.GetByIdAsync(id);
                return item.Adapt<NormalType>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while getting item by id", ex);
            }
        }

        public virtual async Task<NormalType> AddAsync(NormalType entity)
        {

            try
            {
                var item = entity.Adapt<OriginType>();
                if (item == null)
                    return null;
                var created = await genericRepo.AddAsync(item);
                await genericRepo.SaveChangesAsync();
                return created.Adapt<NormalType>(); ;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while adding item", ex);
            }
        }
        public async Task<NormalType> UpdateAsync(NormalType entity)
        {
            try
            {
                var item = entity.Adapt<OriginType>();
                if (item == null)
                    return null;
                var updated = await genericRepo.UpdateAsync(item);
                await genericRepo.SaveChangesAsync();
                return updated.Adapt<NormalType>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating item", ex);
            }
        }

        public async Task<bool> UpdateRangeAsync(List<NormalType> entities)
        {
            try
            {
                var items = entities.Adapt<List<OriginType>>();
                if (items == null)
                    return false;
                var updated = await genericRepo.UpdateRangeAsync(items);
                await genericRepo.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating item", ex);
            }
        }
    }
    
}
