

//using Autofac;
//using Ecommerce.AdminFront.Classes.AutoFac;
//using Ecommerce.Application.Services.OrderServices;
//using Ecommerce.DTOs;

//namespace Ecommerce.AdminFront.Pages.Categories
//{
//    class OrderHandler
//    {
//        private readonly IOrderServices _orderService;
//        private OrderHandler()
//        {
//            var container = AutoFac.Inject();
//            _orderService = container.Resolve<IOrderServices>();
//        }

//        private static OrderHandler? _instance_instance;

//        public static OrderHandler GetInstance()
//        {
//            if(_instance == null)
//            {
//                _instance = new OrderHandler();
//            }
//            return _instance;
//        }


//        public async Task<(bool status, string message)> DeleteOrder(int id)
//        {
//            try
//            {
//                var res = await _orderService.DeleteOrderAsync(id);
//                return res;
//            }
//            catch (Exception ex)
//            {
//                return (false, "something went wrong");
//            }
//        }

//        public async Task<(bool status, string message)> onUpdateOrder(int id, OrderCreateDto dto)
//        {
//            var res = await _orderService.UpdateOrderAsync(id, dto);

//            if (res == null)
//            {
//                return (false, "something went wrong");
//            }
//            return (true, "Order updated successfully");
//        }

//        public async Task<(bool status, string message)> CreateOrder(OrderCreateDto dto)
//        {
//            try
//            {
//               await _orderService.CreateOrderAsync(dto);
//               return (true, "Order created successfully");
//            }
//            catch (Exception ex)
//            {
//                return (false, "something went wrong");
//            }
//        }

//        public async Task<List<OrderDto>> GetCategories()
//        {
//            return  await _orderService.GetCategoriesAsync();
//        }

//    }
//}
