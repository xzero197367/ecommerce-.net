using Ecommerce.DTOs;

using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.UserServices;
using Autofac;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.Context;
using Ecommerce.Infrastructure;

namespace Ecommerce.AdminFront.Pages.Auth
{
    /// <summary>
    /// Interaction logic for RegisterPageUC.xaml
    /// </summary>
    public partial class RegisterPageUC : UserControl
    {
        private readonly IUserServices userServices;

        public RegisterPageUC()
        {
            InitializeComponent();

            var container = AutoFac.Inject();
            userServices = container.Resolve<IUserServices>();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            btnRegister.IsEnabled = false;
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("First Name is required.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Last Name is required.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.");
                btnRegister.IsEnabled = true;
                return;
            }

            // Now that everything is validated, create the user
            UserCreateDto newUser = new()
            {
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                UserEmail = txtEmail.Text,
                UserName = txtEmail.Text,
                UserPassword = txtPassword.Password,
                UserRole = Models.UserRole.Client,
            };

            //ContextDB contextDB = new ContextDB();
            //UserRepo userRepo = new UserRepo(contextDB);
            //UserServices userServices2 = new UserServices(userRepo);

            UserDto signedUser = userServices.Register(newUser);
            
            btnRegister.IsEnabled = true;
            MessageBox.Show("User registered successfully!");
            onSignIn(signedUser);
        }

        private void onSignIn(UserDto user)
        {
            MainWindowEntry.currentUser = user;
            LandingPageUC.BodyGrid.Children.Clear();
        }

    }
}
