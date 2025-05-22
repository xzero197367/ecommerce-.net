
using Ecommerce.AdminFront.ClientPages.Order;
using Ecommerce.AdminFront.Components;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Orders.sections
{

    public partial class OrderTableUC : UserControl
    {
        public ObservableCollection<OrderDto> Orders { get; set; } = new ObservableCollection<OrderDto>();

        private OrderHandler orderHandler = OrderHandler.Instance;

        public Action OnRefreshAction
        {
            get { return (Action)GetValue(OnRefreshActionProperty); }
            set { SetValue(OnRefreshActionProperty, value); }
        }

        public static readonly DependencyProperty OnRefreshActionProperty =
            DependencyProperty.Register("OnRefreshAction", typeof(Action), typeof(OrderTableUC), new PropertyMetadata(null));

        public List<OrderStatus> StatusOptions { get; set; }

        public int counter = 0;

        public OrderTableUC()
        {
            InitializeComponent();

            DataContext = this;

            StatusOptions = new List<OrderStatus> { OrderStatus.Pending, OrderStatus.Approved, OrderStatus.Shipped, OrderStatus.Denied };
        }


        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            counter = 0;
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            counter = 0;
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(counter < Orders.Count)
            {
                counter++;
                return;
            }
            ComboBox comboBox = sender as ComboBox;
            
            if (comboBox != null && comboBox.SelectedIndex != -1)
            {
                OrderStatus status = Enum.Parse<OrderStatus>(comboBox.SelectedValue.ToString());
                OrderDto order = comboBox.DataContext as OrderDto;

                OrderDto olderOrder = Orders.Where(o => o.OrderID == order.OrderID).FirstOrDefault();
                if(olderOrder != null)
                {
                    counter = 1;
                    olderOrder.Status = order.Status;
                    await orderHandler.UpdateOrder(new OrderDto() { OrderID = olderOrder.OrderID, Status = status, UserID = olderOrder.UserID, TotalAmount = olderOrder.TotalAmount });
                    //OnRefreshAction?.Invoke();
                    Orders = new ObservableCollection<OrderDto>(await orderHandler.GetAllOrders());
                    orderListView.ItemsSource = Orders;
                }
                
            }
        }

        private void ShowOrderDetails(object sender, RoutedEventArgs e)
        {
            PopupWindow popup = new PopupWindow();
            OrderItemCardUC orderItemCardUC = new OrderItemCardUC() { Order = (sender as Button).DataContext as OrderDto };
            popup.containerGrid.Children.Add(orderItemCardUC);
            popup.SizeToContent = SizeToContent.WidthAndHeight;
            popup.ShowDialog();
        }
    }
}