
using Ecommerce.DTOs;
using Mapster;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Users.sections
{
    /// <summary>
    /// Interaction logic for UserTableUC.xaml
    /// </summary>
    public partial class UserTableUC : UserControl
    {
        public Func<Task> RefreshUsers { get; set; } = () => Task.CompletedTask;
        public Func<int, Task<(bool status, string message)>> OnDeleteUser { get; set; } = (id) => Task.FromResult((false, "Error occurred while deleting the user. Please try again later."));

        public Func<UserDto, Task<(bool status, string message)>> OnUpdateUser { get; set; } = (dto) => Task.FromResult((false, "Error occurred while updating from table the user. Please try again later."));

        private PopupWindow popupWindow;
        private UserFromUC userFrom;

        public UserTableUC()
        {
            InitializeComponent();

        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await RefreshUsers.Invoke();
        }

        private async void delete_user_click(object sender, System.Windows.RoutedEventArgs e)
        {
            UserDto user = ((sender as Button).DataContext as UserDto)!;
            if(MessageBox.Show("Are you sure deleting this user", "Delete User", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var res = await OnDeleteUser.Invoke(user.UserID);
                await RefreshUsers.Invoke();
            }
        }

        private async void edit_user_click(object sender, System.Windows.RoutedEventArgs e)
        {
            UserDto user = ((sender as Button).DataContext as UserDto)!;
            popupWindow = new PopupWindow();
            userFrom = new UserFromUC()
            {
                onSaveAction = async delegate (UserDto dto)
                {
                    var res = await OnUpdateUser(dto);
                    popupWindow.Close();
                    return res;
                },
                userCreateDto = user.Adapt<UserDto>(),
            };
            userFrom.btnSave.Content = "Update";
            popupWindow.containerGrid.Children.Add(userFrom);
            popupWindow.SizeToContent = SizeToContent.WidthAndHeight;
            popupWindow.ShowDialog();
            await RefreshUsers.Invoke();
        }
    }
}
