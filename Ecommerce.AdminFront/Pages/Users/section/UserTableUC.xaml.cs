
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.UserServices;
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
        private readonly IUserServices _userService;

        public UserTableUC()
        {
            InitializeComponent();

            var container = AutoFac.Inject();
            _userService = container.Resolve<IUserServices>();

        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
          //  userListView.DataContext = await _userService.();
        }
    }
}
