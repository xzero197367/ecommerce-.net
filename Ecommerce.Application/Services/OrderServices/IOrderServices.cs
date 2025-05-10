using Ecommerce.Application.Mapping;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.OrderServices
{
    public interface IOrderServices
    {
        public void UserSubmitsSelectedCartItemsAsOrder(int userId, List<int> selectedCartItemsId);

        public List<OrderHistortyDTO> UserViewsOrdersHistory(int userId);

        public List<Order> AdminViewsOrders(OrderStatus orderStatus);

        public bool AdminApprovesOrder(int orderId);

        public bool AdminDeniesOrder(int orderId);
    }
}
