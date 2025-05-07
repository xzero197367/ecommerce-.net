using Ecommerce.DTOs;

using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.UserServices;
using Autofac;
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

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFname.Text))
            {
                MessageBox.Show("First Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLname.Text))
            {
                MessageBox.Show("Last Name is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.");
                return;
            }

            // Now that everything is validated, create the user
            UserCreateDto newUser = new()
            {
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                Email = txtEmail.Text,
                Username = txtEmail.Text,
                Password = HashPassword(txtPassword.Password),
                Role = Models.UserRole.Client,
            };

            //ContextDB contextDB = new ContextDB();
            //UserRepo userRepo = new UserRepo(contextDB);
            //UserServices userServices2 = new UserServices(userRepo);

            await userServices.RegisterAsync(newUser);

        }

        

        public string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            // Derive a 32-byte key using PBKDF2
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            // Combine salt + hash and return as base64
            byte[] hashBytes = new byte[48];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 32);

            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(32);

            for (int i = 0; i < 32; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }
            return true;
        }


    }
}
