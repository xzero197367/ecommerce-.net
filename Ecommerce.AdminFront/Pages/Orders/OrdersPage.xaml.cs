
using Ecommerce.AdminFront.ClientPages.Order;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Orders
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        private OrderHandler orderHandler = OrderHandler.Instance;
        public List<OrderDto> Orders = new List<OrderDto>();

        //public enum OrderStatus
        //{
        //    All=0,
        //    Pending=1,
        //    Approved=2,
        //    Denied=3,
        //    Shipped=4
        //}
        public OrdersPage()
        {
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            RefreshOrders();
            orderStatus.SelectedIndex = 0;
            searchText.TextChanged += SearchText_TextChanged;
            orderStatus.SelectionChanged += OrderStatus_SelectionChanged;
        }

        private void OrderStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(orderStatus.SelectedIndex == 0){
                RefreshOrders();
                return;
            }
            OrderStatus orderStatus1 = (OrderStatus)orderStatus.SelectedIndex-1;
            orderTable.orderListView.ItemsSource = Orders.Where(orderTable => orderTable.Status == orderStatus1);
        }

        private async void RefreshOrders()
        {
            Orders = await orderHandler.GetAllOrders();
            orderTable.orderListView.ItemsSource = Orders;
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
