
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Ecommerce.AdminFront.ClientPages.Landing.sections;
using Ecommerce.AdminFront.Pages.Users;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace WPFModernVerticalMenu.Pages.Users
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        private UserHandler userHandler;
        private List<UserDto> users;

        public UsersPage()
        {
            userHandler = UserHandler.GetInstance();
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            userForm.AfterSaveAction = refreshUsers;
            userForm.onSaveAction = userHandler.CreateUser;
            userTable.OnUpdateUser = userHandler.onUpdateUser;
            userTable.RefreshUsers = refreshUsers;
           
            userTable.OnDeleteUser = async (id) =>
            {
                var res = await userHandler.DeleteUser(id);
                return res;
            };

            txtSearch.TextChanged += TxtSearch_TextChanged;
            roleComboBox.SelectionChanged += RoleComboBox_SelectionChanged;
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (roleComboBox.SelectedIndex == 0)
            {
                userTable.userListView.ItemsSource = users.Where(c => c.UserRole == UserRole.Admin).ToList();
            }else if (roleComboBox.SelectedIndex == 1)
            {
                userTable.userListView.ItemsSource = users.Where(c => c.UserRole == UserRole.Client).ToList();
            }
            else
            {
                userTable.userListView.ItemsSource = users;
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            userTable.userListView.DataContext = users
                .Where(c => c.UserEmail.ToLower().Contains(txtSearch.Text.ToLower()))
                .ToList();
        }

        public async Task refreshUsers()
        {
            users = await userHandler.GetUsers();
            userTable.userListView.ItemsSource = users;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;
            userForm.onSaveAction = userHandler.CreateUser;
            userForm.AfterSaveAction = refreshUsers;
        }

        // Close popover when the close button is clicked
        private void ClosePopover(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = false;
        }

       
    }
}
