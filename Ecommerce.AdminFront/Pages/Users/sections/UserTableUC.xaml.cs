
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

        public Func<int, UserCreateDto, Task<(bool status, string message)>> OnUpdateUser { get; set; } = (id, dto) => Task.FromResult((false, "Error occurred while updating from table the user. Please try again later."));

        private PopupWindow popupWindow;
        private UserFromUC userFrom;

        public UserTableUC()
        {
            InitializeComponent();

        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void delete_user_click(object sender, System.Windows.RoutedEventArgs e)
        {
            UserDto user = ((sender as Button).DataContext as UserDto)!;
            var res = await OnDeleteUser.Invoke(user.UserID);
            //MessageBox.Show(res.message);
            await RefreshUsers.Invoke();
        }

        private async void edit_user_click(object sender, System.Windows.RoutedEventArgs e)
        {
            UserDto user = ((sender as Button).DataContext as UserDto)!;
            popupWindow = new PopupWindow();
            userFrom = new UserFromUC()
            {
                onSaveAction = async delegate (UserCreateDto dto) {
                    var res = await OnUpdateUser(user.UserID, dto);
                    popupWindow.Close();
                    return res;
                },
                userCreateDto = user.Adapt<UserCreateDto>(),
            };
            userFrom.btnSave.Content = "Update";
            popupWindow.containerGrid.Children.Add(userFrom);
            popupWindow.SizeToContent = SizeToContent.WidthAndHeight;
            popupWindow.ShowDialog();
            await RefreshUsers.Invoke();
        }
    }
}
