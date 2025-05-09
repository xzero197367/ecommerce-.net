using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Mapping
{
    public class OrderHistortyDTO
    {
        public DateTime OrderDate;
        public decimal TotalAmount;
        public OrderStatus Status;

    }
}
