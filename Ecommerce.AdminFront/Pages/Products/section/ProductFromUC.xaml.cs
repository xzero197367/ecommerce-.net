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
using System.Xml.Linq;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
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
        private readonly IProductServices _productService;
        public ProductFromUC()
        {
            InitializeComponent();
            var container = AutoFac.Inject();
            _productService = container.Resolve<IProductServices>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtprice.Text) ||
                string.IsNullOrWhiteSpace(txtimage.Text) ||
                string.IsNullOrWhiteSpace(txtus.Text) ||
                string.IsNullOrWhiteSpace(txtcat.Text))
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
                CategoryID = int.TryParse(txtcat.Text, out var categoryId) ? categoryId : 0 
            };

            try
            {
                _productService.CreateProductAsync(dto);
                MessageBox.Show("success create product");
                this.txtname.Clear();
                this.txtprice.Clear();
                this.txtimage.Clear();
                this.txtus.Clear();
                this.txtcat.Effect = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred : {ex.Message}");
            }
        }
    }
}
