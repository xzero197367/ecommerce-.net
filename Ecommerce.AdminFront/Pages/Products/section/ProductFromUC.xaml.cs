using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.AdminFront.Pages.Products.sections
{
    /// <summary>
    /// Interaction logic for ProductFromUC.xaml
    /// </summary>
    public partial class ProductFromUC : UserControl
    {
 
        public Func<Task> AfterSaveAction { get; set; } = () => Task.CompletedTask;
        public Func<ProductCreateDto, Task<(bool status, string message)>> onSaveAction { get; set; } = (dto) => Task.FromResult((false, "Error occurred while saving the product from form. Please try again later."));

        public ProductCreateDto productCreateDto { get; set; } = null;
        private CategoryHandler categoryHandler;

        public ProductFromUC()
        {
            InitializeComponent();
            categoryHandler = CategoryHandler.GetInstance();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtprice.Text) ||
                string.IsNullOrWhiteSpace(txtimage.Text) ||
                string.IsNullOrWhiteSpace(txtus.Text) ||
                string.IsNullOrWhiteSpace(txtcat.Text)
                )
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            var dto = new ProductCreateDto
            {
                Name = txtname.Text.Trim(),
                Price = decimal.TryParse(txtprice.Text, out var price) ? price : 0,
                UnitsInStock = int.TryParse(txtus.Text, out var stock) ? stock : 0,
                ImagePath = txtimage.Text,
                CategoryID = (int)(txtcat.SelectedValue ?? 0),
                Description = new TextRange(txtDescription.Document.ContentStart, txtDescription.Document.ContentEnd).Text.Trim()
            };




            var res = await onSaveAction.Invoke(dto);
            if(res.status)
            {
            
                this.txtname.Clear();
                this.txtprice.Clear();
                this.txtimage.Clear();
                this.txtus.Clear();
                this.txtcat.Effect = null;
                this.txtDescription.Document.Blocks.Clear();
                AfterSaveAction?.Invoke();
            }
            MessageBox.Show(res.message);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtcat.ItemsSource = await categoryHandler.GetCategories();
            txtcat.DisplayMemberPath = "Name";
            txtcat.SelectedValuePath = "ProductId";
        }
    }
}
