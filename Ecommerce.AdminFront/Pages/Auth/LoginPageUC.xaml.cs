using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.UserServices;
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

namespace Ecommerce.AdminFront.Pages.Auth
{
    /// <summary>
    /// Interaction logic for LoginPageUC.xaml
    /// </summary>
    public partial class LoginPageUC : UserControl
    {
        private readonly IUserServices userServices;
        public LoginPageUC()
        {
            InitializeComponent();
            var container = AutoFac.Inject();
            userServices = container.Resolve<IUserServices>();
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

            await userServices.LoginAsync(txtEmail.Text, txtPassword.Password);
            btnLogin.IsEnabled = true;
        }
    }
}
