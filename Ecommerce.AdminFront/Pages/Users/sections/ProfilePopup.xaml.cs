using Ecommerce.AdminFront.Pages.Users;
using Ecommerce.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;

namespace Ecommerce.AdminFront.Pages.Users.sections
{
    /// <summary>
    /// Interaction logic for ProfilePopup.xaml
    /// </summary>
    public partial class ProfilePopup : UserControl
    {
        private string imagePath = string.Empty; // Store the relative path of the image
        public UserDto User { get; set; } = MainWindowEntry.currentUser;
        public Popup popup { get; set; } = null; // Popup control to be closed
        public Func<UserCreateDto,Task<(bool status, string message)>> OnSaveAction { get; set; } = null; // Function to be called aft
  

        public ProfilePopup()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            User = MainWindowEntry.currentUser;
            changeItemVisibility(Visibility.Collapsed, false);
            if (User != null)
            {
                txtFname.Text = User.FirstName;
                txtLname.Text = User.LastName;
                txtEmail.Text = User.UserEmail;
                txtUsername.Text = User.UserName;
                displayImageFromDB(imagePath = User.ImagePath != "" ?User.ImagePath : "Resources/ecommerce.jpeg");

                btnSave.Visibility = Visibility.Collapsed;
                btnCancel.Visibility = Visibility.Collapsed;
            }
            
        }

        private void displayImageFromDB(string relativePath)
        {

            string fullPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullPath, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            ImagePreview.Source = bitmap;

        }

        private void PickImage_Click(object sender, RoutedEventArgs e)
        {
            // Step 1: Open File Dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string originalPath = openFileDialog.FileName;

                // Step 2: Display Image Preview
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(originalPath);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                ImagePreview.Source = bitmap;

                // Step 3: Copy image to output folder
                string outputFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                Directory.CreateDirectory(outputFolder);

                string fileName = System.IO.Path.GetFileName(originalPath);
                string newPath = System.IO.Path.Combine(outputFolder, fileName);

                File.Copy(originalPath, newPath, true);

                // Step 4: Get relative path starting from output folder
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = newPath.Replace(baseDir, ""); // now it's like "Images/myImage.jpg"

                // Step 5: Show both
                PathText.Text = $"Original: {originalPath}\nRelative: {relativePath}";

                imagePath = relativePath;
                User.ImagePath = relativePath;

                btnSave.Visibility = Visibility.Visible;
                popup.StaysOpen = true;
                // Step 4: Show new path
                //PathText.Text = $"Original: {originalPath}\nCopied to: {newPath}";
            }
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = false;

            
            if(string.IsNullOrEmpty(User.UserName) || string.IsNullOrEmpty(User.UserEmail) || string.IsNullOrEmpty(User.FirstName) || string.IsNullOrEmpty(User.LastName))
            {
                MessageBox.Show("Please fill all fields");
                btnSave.IsEnabled = true;
                return;
            }
            if (string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please select an image");
                btnSave.IsEnabled = true;
                return;
            }
            User.FirstName = txtFname.Text;
            User.LastName = txtLname.Text;
            User.UserEmail = txtEmail.Text;
            User.UserName = txtUsername.Text;
            User.ImagePath = imagePath;

            UserCreateDto user = new UserCreateDto
            {
                UserName = User.UserName,
                UserEmail = User.UserEmail,
                FirstName = User.FirstName,
                LastName = User.LastName,
                ImagePath = imagePath,
                UserRole = User.UserRole
            };


            
            var res = await OnSaveAction?.Invoke(user);

            if (res.status)
            {
                changeItemVisibility(Visibility.Collapsed, false);
                hideButtons();
            }
            else
            {
                MessageBox.Show("Error", res.message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            changeItemVisibility(Visibility.Collapsed, false);
            hideButtons();
        }

        private void hideButtons()
        {
            btnSave.IsEnabled = true;
            popup.StaysOpen = false;
            popup.IsOpen = false;
        }

        private void btnEditInfo_Click(object sender, RoutedEventArgs e)
        {
            btnEditInfo.Visibility = Visibility.Collapsed;
            changeItemVisibility(Visibility.Visible, true);
        }

        private void changeItemVisibility(Visibility visibility, bool enabled)
        {
            
            btnSave.Visibility = visibility;
            btnCancel.Visibility = visibility;
            btnChangeImage.Visibility = visibility;
            txtFname.IsReadOnly = enabled;
            txtLname.IsReadOnly = enabled;
            txtEmail.IsReadOnly = enabled;
            txtUsername.IsReadOnly = enabled;
            txtFname.Focusable = enabled;
            if (enabled)
            {
                txtFname.Focus();
            }
        }
    }
}
