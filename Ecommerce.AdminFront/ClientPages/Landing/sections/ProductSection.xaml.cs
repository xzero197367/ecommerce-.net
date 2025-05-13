
using Ecommerce.AdminFront.Pages.Products;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class ProductSection : UserControl
{
    private ProductHandler productHandler;
    public ProductSection()
    {
        InitializeComponent();
        productHandler = ProductHandler.GetInstance();
    }


    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        productsListView.DataContext = await productHandler.GetProducts();
    }
}