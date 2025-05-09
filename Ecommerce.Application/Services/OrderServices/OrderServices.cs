using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Ecommerce.Application.Contracts;
using Ecommerce.Application.Mapping;
using Ecommerce.Models;

namespace Ecommerce.Application.Services.OrderServices;

public class OrderServices
{
    private readonly ICartItemRepo _cartRepository;
    private readonly IOrderRepo _orderRepository;

    

    public OrderServices(ICartItemRepo cartRepository, IOrderRepo orderRepository)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
    }

    public void UserSubmitsSelectedCartItemsAsOrder(int userId, List<int> selectedCartItemsId)
    {
        var selectedItems = _cartRepository.GetCartItemsByID(userId, selectedCartItemsId);

        //if (selectedItems == null || !selectedItems.Any())
        //    throw new Exception("No valid cart items selected."); // think again about this in real life


        var order = new Order
        {
            UserID = userId,
            OrderDate = DateTime.Now,
            TotalAmount = selectedItems.Sum(i => i.Quantity * i.Product.Price),
            Status = OrderStatus.Pending, // Fixed: Use the enum value instead of a string
            DateProcessed = null, // You haven't reviewed it yet. It makes your system flexible and more realistic.
            
        };

        _orderRepository.Create(order); // EF will generate OrderID
        _orderRepository.SaveChanges();


        order.Details = selectedItems.Select(item => new OrderDetails
        {
            OrderID = order.OrderID,
            ProductId = item.ProductID,
            Quantity = item.Quantity,
        }).ToList();

        _orderRepository.Update(order); // Add the details
        _orderRepository.SaveChanges(); // Final save

        _cartRepository.RemoveCartItems(selectedCartItemsId);



    }

    public List<OrderHistortyDTO> UserViewsOrderHistory(int userId)
    {
        var orders = _orderRepository.GetOrdersByUserId(userId);

        return orders.Select(o => new OrderHistortyDTO
        {
            OrderDate = o.OrderDate,
            TotalAmount = o.TotalAmount,
            Status = o.Status
        }).ToList();
 
    }

    public List<Order> AdminViewsOrders(OrderStatus orderStatus)
    {
       return _orderRepository.GetOrdersByStatus(orderStatus);
    }

    public bool AdminApprovesOrder(int orderId)
    {
        var order = _orderRepository.GetById(orderId);

        if(order == null || order.Status != OrderStatus.Pending)
        {
            return false;
        }

        order.Status= OrderStatus.Approved;
        order.DateProcessed = DateTime.Now;

        _orderRepository.Update(order);
        _orderRepository.SaveChanges();

        return true;
    }

    public bool AdminDeniesOrder(int orderId)
    {
        var order = _orderRepository.GetById(orderId);

        if (order == null || order.Status != OrderStatus.Pending)
        {
            return false;
        }

        order.Status = OrderStatus.Denied;
        order.DateProcessed = DateTime.Now;

        _orderRepository.Update(order);
        _orderRepository.SaveChanges();

        return true;

    }
}




 //   Order
 //   public int OrderID { get; set; }
 //   public int UserID { get; set; }
 //   public DateTime OrderDate { get; set; }
 //   public decimal TotalAmount { get; set; }
 //   public OrderStatus Status { get; set; }
 //   public DateTime? DateProcessed { get; set; }
 //   public User User { get; set; }
 //   public ICollection<OrderDetail> Details { get; set; }

//    Order Details
//    public int OrderDetailID { get; set; }
//    public int OrderID { get; set; }
//    public int ProductId { get; set; }
//    public int Quantity { get; set; }
//    public Order Order { get; set; }
//    public Product Product { get; set; }
