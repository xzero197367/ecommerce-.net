using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Ecommerce.AdminFront.Controls.Convertors
{
    internal class OrderStatusVisibleConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = Enum.Parse<OrderStatus>(value.ToString(), true);

            if (status == OrderStatus.Approved || status == OrderStatus.Denied || status == OrderStatus.Shipped)
                return Visibility.Collapsed;
            else if(status == OrderStatus.Pending)
                return Visibility.Collapsed;
            return Visibility.Collapsed;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
