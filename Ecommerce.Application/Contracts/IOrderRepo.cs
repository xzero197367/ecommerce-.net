using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Application.Mapping;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IOrderRepo : IGenericRepo<Order>
    {
        List<Order> GetOrdersByUserId(int userId);
    }
    

    
}

