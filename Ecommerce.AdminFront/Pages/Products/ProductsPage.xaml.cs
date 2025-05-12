using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.Products;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Products
{
    /// <summary>
    /// Lógica de interacción para Home.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private ProductHandler productHandler;
        private ObservableCollection<ProductDto> products;
        public ProductsPage()
        {
            productHandler = ProductHandler.GetInstance();
            InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshProducts();
            productForm.OnSaveProduct += OnSaveProduct;
            txtSearch.TextChanged += OnSearchTextChanged;

        }

        private async void RefreshProducts()
        {
            var items = await productHandler.GetProducts();
            products = new ObservableCollection<ProductDto>(items);
            productTable.productListView.DataContext = products;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private async Task<bool> OnSaveProduct(ProductCreateDto product)
        {
            var res = await productHandler.CreateProduct(product);
            if (res.status)
            {
                RefreshProducts();
                PopoverPopup.IsOpen = false;

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
