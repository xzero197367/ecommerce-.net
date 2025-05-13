using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Product;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Components;

public partial class ProductCardUC : UserControl
{


    public ProductDto Product
    {
        get { return (ProductDto)GetValue(ProductProperty); }
        set { SetValue(ProductProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ProductProperty =
        DependencyProperty.Register("Product", typeof(ProductDto), typeof(ProductCardUC), new PropertyMetadata(null));




    public ProductCardUC()
    {
        InitializeComponent();
    }
    
    private async void OpenDialogButton_Click(object sender, RoutedEventArgs e)
    {
        PopoverUC popover = new PopoverUC(onClose: () =>
        {
            MainWindowEntry.MainGrid.Children.RemoveAt(1);
        });
        popover.ContainerGrid.Children.Add(new ProductDetailsUC());
        MainWindowEntry.MainGrid.Children.Add(popover);
        // var result = await ProductDialog.ShowAsync();
        //
        // if (result == Wpf.Ui.Controls.ContentDialogResult.Primary)
        // {
        //     // Handle Buy Now
        // }
        // else if (result == Wpf.Ui.Controls.ContentDialogResult.Secondary)
        // {
        //     // Handle Add to Cart
        // }
    }
}