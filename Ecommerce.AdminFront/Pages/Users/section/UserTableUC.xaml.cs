
using Ecommerce.DTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Users.sections
{
    /// <summary>
    /// Interaction logic for CategoryTableUC.xaml
    /// </summary>
    public partial class UserTableUC : UserControl
    {
        public ObservableCollection<UserDto> Users { get; set; }

        public UserTableUC()
        {
            InitializeComponent();
            Users = new ObservableCollection<UserDto>
            {
                new UserDto()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "johndoe",
                    CartItems = new List<CartItemDto>(),
                    Orders = new List<OrderDto>(),
                    DateCreated = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    IsActive = true,
                    UserEmail = "john@doe.com",
                    UserPassword = "password",
                    UserRole = Models.UserRole.Admin,
                },
                new UserDto()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "johndoe",
                    CartItems = new List<CartItemDto>(),
                    Orders = new List<OrderDto>(),
                    DateCreated = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    IsActive = true,
                    UserEmail = "john@doe.com",
                    UserPassword = "password",
                    UserRole = Models.UserRole.Admin,
                }
            };

            DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
