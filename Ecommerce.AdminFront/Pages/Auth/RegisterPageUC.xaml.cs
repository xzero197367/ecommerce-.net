﻿using Ecommerce.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Auth
{
    /// <summary>
    /// Interaction logic for RegisterPageUC.xaml
    /// </summary>
    public partial class RegisterPageUC : UserControl
    {
        private AuthHandler authHandler;

        public RegisterPageUC()
        {
            InitializeComponent();
            authHandler = AuthHandler.Instance;
        }

        private async void btnRegister_Click(object sender, RoutedEventArgs e)
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
            // Email format validation
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(txtEmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Password is required.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Password)) {
                MessageBox.Show("Confirm Password is required.");
                btnRegister.IsEnabled = true;
                return;
            }
            if (txtPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Passwords do not match.");
                btnRegister.IsEnabled = true;
                return;
            }


            // Now that everything is validated, create the user
            UserDto newUser = new()
            {
                FirstName = txtFname.Text,
                LastName = txtLname.Text,
                UserEmail = txtEmail.Text,
                UserName = txtUsername.Text,
                UserPassword = txtPassword.Password,
                UserRole = Models.UserRole.Client,
            };

            try
            {
                UserDto signedUser = await authHandler.RegisterAsync(newUser);

                btnRegister.IsEnabled = true;
                MessageBox.Show("User registered successfully!");
                authHandler.AfterAuth(signedUser!);
            }
            catch (Exception ex)
            {
                btnRegister.IsEnabled = true;
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        
    }
}
