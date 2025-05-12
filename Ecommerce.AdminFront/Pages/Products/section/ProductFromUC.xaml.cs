using System;
using System.Collections.Generic;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.AdminFront.Pages.Products.sections
{
    /// <summary>
    /// Interaction logic for CategoryFromUC.xaml
    /// </summary>
    public partial class ProductFromUC : UserControl
    {
        //private readonly IProductServices _productService;
        private readonly ICategoryServices categoryServices;

        public Func<ProductCreateDto, Task<bool>> OnSaveProduct { get; set; } = (p) => Task.FromResult(false);


        public ProductFromUC()
        {
            InitializeComponent();
            var container = AutoFac.Inject();
            //_productService = container.Resolve<IProductServices>();
            categoryServices = container.Resolve<ICategoryServices>();
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




            bool res = await OnSaveProduct?.Invoke(dto);
            if(res)
            {
                MessageBox.Show("success create product");
                this.txtname.Clear();
                this.txtprice.Clear();
                this.txtimage.Clear();
                this.txtus.Clear();
                this.txtcat.Effect = null;
                this.txtDescription.Document.Blocks.Clear();
            }
            else
            {
                MessageBox.Show($"An error occurred ");
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //txtcat.ItemsSource =  await categoryServices.GetCategoriesAsync();
            //txtcat.DisplayMemberPath = "Name";
            //txtcat.SelectedValuePath = "Id";

            txtcat.ItemsSource = await categoryServices.GetCategoriesAsync();
            txtcat.DisplayMemberPath = "Name";
            txtcat.SelectedValuePath = "CategoryId";


        }
    }
}
