
using Ecommerce.DTOs;
using System.Globalization;
using System.Windows.Data;

namespace Ecommerce.AdminFront.Controls.Convertors
{
    public class FullNameConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = value as UserDto;
            if (user == null)
                return string.Empty;

            return $"{user.FirstName} {user.LastName}".Trim();
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
