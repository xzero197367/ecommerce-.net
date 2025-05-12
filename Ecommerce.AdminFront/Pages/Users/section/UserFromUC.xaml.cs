
using System.Windows;
using System.Windows.Controls;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.AdminFront.Pages.Users.sections
{
    /// <summary>
    /// Interaction logic for CategoryFromUC.xaml
    /// </summary>
    public partial class UserFromUC : UserControl
    {
        private readonly IUserServices usersercices;
        public UserFromUC()
        {
            InitializeComponent();
            var container = AutoFac.Inject();
            usersercices = container.Resolve<IUserServices>();
        }

        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtfname.Text) ||
                string.IsNullOrEmpty(txtlname.Text) ||
                string.IsNullOrEmpty(txtemail.Text) ||
                string.IsNullOrEmpty(txtpass.Text) ||
                string.IsNullOrEmpty(txtrole.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            if (!Enum.TryParse<UserRole>(txtrole.Text.Trim(), true, out var userRole))
            {
                MessageBox.Show("Invalid role. Please enter a valid role (e.g., 'Client' or 'Admin').");
                return;
            }

            var dto = new UserCreateDto
            {
                FirstName = txtfname.Text.Trim(),
                LastName = txtlname.Text.Trim(),
                UserName = txtfname.Text.Trim() + txtlname.Text.Trim(),
                UserEmail = txtemail.Text.Trim(),
                UserPassword = txtpass.Text.Trim(),
                UserRole = userRole
            };

           
                var result = await usersercices.RegisterAsync(dto); 
                if (result == null)
                {
                    MessageBox.Show("User creation failed.");
                    return;
                }

                MessageBox.Show("User created successfully.");
              
            
        }
    }
}
