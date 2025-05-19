using Ecommerce.AdminFront.Pages.Users;
using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Profile;

public partial class ProfilePageUC : UserControl
{
    public UserDto User { get; set; } = MainWindowEntry.currentUser;
    private UserHandler userHandler = UserHandler.GetInstance();
    public ProfilePageUC()
    {
        InitializeComponent();
    }

    private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        DataContext = User;
    }

    private async void update_profile_btn_click(object sender, System.Windows.RoutedEventArgs e)
    {

        if (User == null) {
            return;
        }

        
        if (string.IsNullOrEmpty(FirstName.Text))
        {
            MessageBox.Show("First Name is required");
            return;
        }
        if (string.IsNullOrEmpty(LastName.Text)) {
            MessageBox.Show("Last Name is required");
            return;
        }
        if (string.IsNullOrEmpty(Email.Text))
        {
            MessageBox.Show("Email is required");
            return;
        }
        if (string.IsNullOrEmpty(Username.Text))
        {
            MessageBox.Show("Username is required");
            return;
        }
        User.FirstName = FirstName.Text;
        User.LastName = LastName.Text;
        User.UserEmail = Email.Text;
        User.UserName = Username.Text;

        await userHandler.onUpdateUser(User);
        
        MessageBox.Show("Profile updated successfully");
    }

    private async void reset_password_click_btn(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(OldPassword.Text))
        {
            MessageBox.Show("Old Password is required");
            return;
        }
        if (string.IsNullOrEmpty(NewPassword.Text))
        {
            MessageBox.Show("New Password is required");
            return;
        }
        if (string.IsNullOrEmpty(ConfirmPassword.Text))
        {
            MessageBox.Show("Confirm Password is required");
            return;
        }
        if(NewPassword.Text != ConfirmPassword.Text)
        {
            MessageBox.Show("Passwords do not match");
            return;
        }
        var user  = await userHandler.ResetPassword(User.UserID, NewPassword.Text, OldPassword.Text);
        if (user != null)
        {
            MainWindowEntry.currentUser = user;
            User = user;
        }
    }
}