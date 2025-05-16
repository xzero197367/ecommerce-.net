
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Ecommerce.AdminFront.ClientPages.Landing.sections;
using Ecommerce.AdminFront.Pages.Users;
using Ecommerce.DTOs;

namespace WPFModernVerticalMenu.Pages.Users
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private UserHandler userHandler;
        private ObservableCollection<UserDto> users;

        public UsersPage()
        {
            userHandler = UserHandler.GetInstance();
            InitializeComponent();

         
      
        }

        private async void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            userForm.AfterSaveAction = refreshUsers;
            
            userTable.OnUpdateUser = userHandler.onUpdateUser;

            userTable.RefreshUsers = refreshUsers;

            userForm.onSaveAction = async (dto) =>
            {
                var res = await userHandler.CreateUser(dto);
                return res;
            };
            userTable.OnDeleteUser = async (id) =>
            {
                var res = await userHandler.DeleteUser(id);
                return res;
            };

            await refreshUsers();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            userTable.userListView.DataContext = users
                .Where(c => c.UserEmail.ToLower().Contains(txtSearch.Text.ToLower()))
                .ToList();
        }

        public async Task refreshUsers()
        {
            var items = await userHandler.GetUsers();
            users = new ObservableCollection<UserDto>(items);
            userTable.userListView.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;

        }

        // Close popover when the close button is clicked
        private void ClosePopover(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = false;
        }

       
    }
}
