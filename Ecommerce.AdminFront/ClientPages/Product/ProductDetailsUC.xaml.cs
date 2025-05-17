using Ecommerce.AdminFront.Pages.CartItems;
using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Product;

public partial class ProductDetailsUC : UserControl
{
    public ProductDto CurrentProduct { get; set; }

    public ProductDetailsUC()
    {
        InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        if (MainWindowEntry.currentUser == null)
        {
            MessageBox.Show("Please login first.");
            return;
        }

        if (CurrentProduct == null)
        {
            MessageBox.Show("Product data is missing.");
            return;
        }

        var cartItemDto = new CartItemDto
        {
            ProductID = CurrentProduct.ProductId,
            UserID = MainWindowEntry.currentUser.UserID,
            Quantity = 1,
            DateAdded = DateTime.Now
        };

        var handler = CartItemHandler.GetInstance();
        var (status, message) = await handler.AddOrUpdate(cartItemDto);

        MessageBox.Show(message);
    }
}
