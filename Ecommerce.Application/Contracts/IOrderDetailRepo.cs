using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Application.Contracts
{
   public interface IOrderDetailRepo : IGenericRepo<OrderDetail>
    {
        // Add any additional methods specific to OrderDetail repository if needed
    }
   
}
