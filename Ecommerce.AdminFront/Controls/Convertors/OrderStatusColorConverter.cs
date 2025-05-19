using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Ecommerce.AdminFront.Controls.Convertors
{
    class OrderStatusColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = Enum.Parse<OrderStatus>(value.ToString(), true);
            if (status == OrderStatus.Approved)
                return Brushes.Green;
            else if (status == OrderStatus.Denied)
                return Brushes.Red;
            else if(status == OrderStatus.Pending)
                return Brushes.Orange;
            else if(status == OrderStatus.Shipped)
                return Brushes.Blue;
            return Brushes.Gray;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
