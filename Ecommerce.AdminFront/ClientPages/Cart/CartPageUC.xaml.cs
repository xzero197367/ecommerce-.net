using Ecommerce.AdminFront.Pages.CartItems;
using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Cart
{
    public partial class CartPageUC : UserControl
    {
        public CartPageUC()
        {
            InitializeComponent();
        }

        private async void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is CartItemDto cartItem && cartItem.Quantity > 1)
            {
                int newQuantity = cartItem.Quantity - 1;
                var handler = CartItemHandler.GetInstance();
                var (status, message) = await handler.UpdateQuantity(cartItem.CartItemID, newQuantity);
                if (status)
                {
                    cartItem.Quantity = newQuantity;
                }
                else
                {
                    MessageBox.Show(message, "Update Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private async void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is CartItemDto cartItem)
            {
                int newQuantity = cartItem.Quantity + 1;
                var handler = CartItemHandler.GetInstance();
                var (status, message) = await handler.UpdateQuantity(cartItem.CartItemID, newQuantity);
                if (status)
                {
                    cartItem.Quantity = newQuantity;
                }
                else
                {
                    MessageBox.Show(message, "Update Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private async void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is CartItemDto cartItem)
            {
                var handler = CartItemHandler.GetInstance();
                var (status, message) = await handler.RemoveCartItem(cartItem.CartItemID);
                if (status)
                {
                    MessageBox.Show("Item removed successfully", "Removed", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(message, "Remove Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
