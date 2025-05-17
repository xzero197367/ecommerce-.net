using System.Windows;
using System.Windows.Controls;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.ClientPages.Product;

public partial class ProductDetailsUC : UserControl
{
    public ProductDto Product  { get; set; }
    
    //public static readonly DependencyProperty ProductProperty =
    //    DependencyProperty.Register("Product", typeof(ProductDto), 
    //        typeof(ProductDetailsUC), new PropertyMetadata(null));
    
    public ProductDetailsUC()
    {
        InitializeComponent();
    }

    private void ProductDetailsUC_OnLoaded(object sender, RoutedEventArgs e)
    {
        DataContext = Product;
    }

    private void BtnAddToCart_OnClick(object sender, RoutedEventArgs e)
    {
        
    }

    private void BtnBuyNow_OnClick(object sender, RoutedEventArgs e)
    {
        
    }
}