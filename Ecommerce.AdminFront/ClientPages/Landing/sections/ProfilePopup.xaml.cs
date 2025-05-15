using Ecommerce.DTOs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Ecommerce.AdminFront.ClientPages.Landing.sections
{
    /// <summary>
    /// Interaction logic for ProfilePopup.xaml
    /// </summary>
    public partial class ProfilePopup : UserControl
    {
        private string imagePath = string.Empty; // Store the relative path of the image
        private UserDto User { get; set; } = MainWindowEntry.currentUser != null ? MainWindowEntry.currentUser: new UserDto();

        public ProfilePopup()
        {
            InitializeComponent();
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

                btnSave.Visibility = Visibility.Visible;
                // Step 4: Show new path
                //PathText.Text = $"Original: {originalPath}\nCopied to: {newPath}";
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnSave.Visibility = Visibility.Collapsed;
        }
    }
}
