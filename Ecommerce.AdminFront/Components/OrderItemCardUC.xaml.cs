﻿using Ecommerce.AdminFront.ClientPages.Order;
using Ecommerce.DTOs;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ecommerce.AdminFront.Components
{
    /// <summary>
    /// Interaction logic for OrderItemCardUC.xaml
    /// </summary>
    public partial class OrderItemCardUC : UserControl
    {

        public static readonly DependencyProperty OrderProperty = DependencyProperty.Register("Order", typeof(OrderDto), typeof(OrderItemCardUC), new PropertyMetadata(null));

        private OrderHandler orderHandler = OrderHandler.Instance;

        public Action OnRefreshOrders
        {
            get { return (Action)GetValue(OnRefreshOrdersProperty); }
            set { SetValue(OnRefreshOrdersProperty, value); }
        }

        public static readonly DependencyProperty OnRefreshOrdersProperty =
            DependencyProperty.Register("OnRefreshOrders", typeof(Action), typeof(OrderItemCardUC), new PropertyMetadata(null));



        public OrderDto Order
        {
            get { return (OrderDto)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }





        public OrderItemCardUC()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = Order;
        }

        // Attach this event handler to your horizontal ListView
        private void HorizontalListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var listView = sender as ListView;
            var scrollViewer = FindParentScrollViewer(listView);

            if (scrollViewer != null)
            {
                // Scroll the parent ScrollViewer vertically
                if (e.Delta != 0)
                {
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
                    e.Handled = true; // Mark event as handled so ListView doesn't consume it
                }
            }
        }

        private ScrollViewer FindParentScrollViewer(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);
            while (parent != null && !(parent is ScrollViewer))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as ScrollViewer;
        }

        private async void cancel_order_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure canceling the order?", "Cancel Order", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                Order.Status = OrderStatus.Denied;
                await orderHandler.UpdateOrder(Order);

                OnRefreshOrders?.Invoke();
            }
        }
    }
}
