using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Product;

namespace Ecommerce.AdminFront.Components;

public partial class ProductCardUC : UserControl
{
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