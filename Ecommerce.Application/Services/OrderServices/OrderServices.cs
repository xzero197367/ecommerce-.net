
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.GenericServices;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services.OrderServices
{
    public class OrderServices: GenericServices<OrderDto, Order>, IOrderServices
    {
        private readonly IOrderRepo orderRepo;

        public OrderServices(IOrderRepo orderRepo): base(orderRepo)
        {
            this.orderRepo = orderRepo;
        }

        public async override Task<List<OrderDto>> GetAllAsync()
        {
            var items = await orderRepo.GetAllAsync().Include(x => x.Details).ThenInclude(x => x.Product).Include(x => x.User).AsNoTracking().ToListAsync();

            return items.Adapt<List<OrderDto>>();
        }


        public async override Task<List<OrderDto>> GetWithConditionAsync(Expression<Func<Order, bool>> predicate)
        {
            var items = await orderRepo.GetWithConditionAsync(predicate).Include(x => x.Details).ThenInclude(x => x.Product).Include(x => x.User).AsNoTracking().ToListAsync();

            return items.Adapt<List<OrderDto>>();
        }


        public override Task<OrderDto> AddAsync(OrderDto entity)
        {
            var result  = base.AddAsync(entity);

            return result;
        }
       
    }
}

