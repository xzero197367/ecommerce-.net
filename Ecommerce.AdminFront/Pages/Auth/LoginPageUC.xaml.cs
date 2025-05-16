
using System.Windows;
using System.Windows.Controls;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Pages.Auth
{
    /// <summary>
    /// Interaction logic for LoginPageUC.xaml
    /// </summary>
    public partial class LoginPageUC : UserControl
    {
        private AuthHandler authHandler;
        public LoginPageUC()
        {
            authHandler = new AuthHandler();
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.");
                btnLogin.IsEnabled = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.");
                btnLogin.IsEnabled = true;
                return;
            }


            UserDto? user = await authHandler.LoginAsync(txtEmail.Text, txtPassword.Password);
            if (user != null)
            {
                authHandler.AfterAuth(user);

            }
            else
            {
                MessageBox.Show("invalid email or password");
                btnLogin.IsEnabled = true;
            }
        }
    }
}