using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Products
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private readonly IProductServices _productService;
        public ProductsPage()
        {
            var container = AutoFac.Inject();
            _productService = container.Resolve<IProductServices>();

            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            productTable.productListView.DataContext = await _productService.GetAllProducts();

            productForm.OnSaveProduct += OnSaveProduct;
           
        }

        private async Task<bool> OnSaveProduct(ProductCreateDto product)
        {
            var res = await _productService.CreateProductAsync(product);
            if (res != null)
            {
                productTable.productListView.DataContext = await _productService.GetAllProducts();
                PopoverPopup.IsOpen = false;


                productTable.productListView.DataContext = await _productService.GetAllProducts();
                return true;
            }
            return false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;
        }

        
    }
}
