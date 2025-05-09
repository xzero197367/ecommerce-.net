using Ecommerce.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.OrderServices
{
    public interface IOrderServices
    {
        public void SubmitSelectedCartItemsAsOrder(int userId, List<int> selectedCartItemsId);

        public List<OrderHistortyDTO> ViewOrsersHistory(int userId);
    }
}
