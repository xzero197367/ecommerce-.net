using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.ClientPages.Landing.sections;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            UserDto user = authHandler.Login(txtEmail.Text, txtPassword.Password);
            authHandler.AfterAuth(user);
        }
    }
}
