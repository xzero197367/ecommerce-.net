using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Microsoft.Win32;

namespace Ecommerce.AdminFront.Pages.Products.sections
{
    /// <summary>
    /// Interaction logic for ProductFromUC.xaml
    /// </summary>
    public partial class ProductFromUC : UserControl
    {
 
        public Func<Task> AfterSaveAction { get; set; } = () => Task.CompletedTask;
        public Func<ProductDto, Task<(bool status, string message)>> onSaveAction { get; set; } = (dto) => Task.FromResult((false, "Error occurred while saving the product from form. Please try again later."));

        public ProductDto productCreateDto { get; set; } = null;
        private CategoryHandler categoryHandler;



        public string ImagePath
        {
            get { return (string)GetValue(ImagePathProperty); }
            set { SetValue(ImagePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(ProductFromUC), new PropertyMetadata(""));



        public ProductFromUC()
        {
            InitializeComponent();
            categoryHandler = CategoryHandler.GetInstance();
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtcat.ItemsSource = await categoryHandler.GetCategories();
            txtcat.DisplayMemberPath = "Name";
            txtcat.SelectedValuePath = "CategoryId";

            if(productCreateDto != null)
            {
                ImagePath = productCreateDto.ImagePath;
                displayImageFromDB(ImagePath);
                txtname.Text = productCreateDto.Name;
                txtprice.Text = productCreateDto.Price.ToString();
                //txtimage.Text = productCreateDto.ImagePath;
                txtus.Text = productCreateDto.UnitsInStock.ToString();
                txtcat.SelectedValue = productCreateDto.CategoryID;
                txtDescription.Document.Blocks.Clear();
                txtDescription.AppendText(productCreateDto.Description); // Assuming you want to set the description in the TextBox
            }
            else
            {
                txtcat.SelectedIndex = 0;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtprice.Text) ||
                //string.IsNullOrWhiteSpace(txtimage.Text) ||
                string.IsNullOrWhiteSpace(txtus.Text) ||
                string.IsNullOrWhiteSpace(txtcat.Text)
                )
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            CategoryDto category = txtcat.SelectedItem as CategoryDto;

            ProductDto product = new ProductDto
            {
                Name = txtname.Text.Trim(),
                Price = decimal.TryParse(txtprice.Text, out var price) ? price : 0,
                UnitsInStock = int.TryParse(txtus.Text, out var stock) ? stock : 0,
                ImagePath = ImagePath ?? "Resources/ecommerce.jpeg",
                CategoryID = category.CategoryId,
                Description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text.Trim()
            };
            
            if(productCreateDto != null && productCreateDto.ProductId != 0)
            {
                product.ProductId = productCreateDto.ProductId;
            }

            var res = await onSaveAction.Invoke(product);
            if(res.status)
            {
            
                this.txtname.Clear();
                this.txtprice.Clear();
                //this.txtimage.Clear();
                ImagePreview.Source = null;
                this.txtus.Clear();
                this.txtcat.Effect = null;
                this.txtDescription.Document.Blocks.Clear();
                AfterSaveAction?.Invoke();
            }
            else
            {
                MessageBox.Show(res.message);
            }
            
        }

        private void txtcat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var item = (sender as ComboBox)?.SelectedItem as CategoryDto;
            //MessageBox.Show(item?.CategoryId.ToString() ?? "No category selected");
            //MessageBox.Show(txtcat.SelectedValue.ToString() + " " + txtcat.Text);
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

        private void displayImage(string originalPath)
        {
            // Step 2: Display Image Preview
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(originalPath);
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
                displayImage(originalPath);


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

                ImagePath = relativePath;

                // Step 4: Show new path
                //PathText.Text = $"Original: {originalPath}\nCopied to: {newPath}";
            }
        }

        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            AfterSaveAction?.Invoke();
        }
    }
}
