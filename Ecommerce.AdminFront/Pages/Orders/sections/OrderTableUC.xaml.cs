
using Ecommerce.DTOs;
using Ecommerce.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Orders.sections
{

    public partial class OrderTableUC : UserControl
    {
        public ObservableCollection<OrderDto> Orders { get; set; } = new ObservableCollection<OrderDto>();

        public OrderTableUC()
        {
            InitializeComponent();
            Orders.Add(new OrderDto
            {
                OrderID = 1,
                UserID = 101,
                OrderDate = DateTime.UtcNow,
                TotalAmount = 250.75m,
                Status = OrderStatus.Pending,
                DateProcessed = null,
                User = new UserDto { FirstName = "John Doe" }  
            });
            DataContext  = this;
        }
    }
}
