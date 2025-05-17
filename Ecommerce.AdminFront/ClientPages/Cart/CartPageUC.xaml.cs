using Ecommerce.AdminFront.Pages.CartItems;
using System.Windows.Controls;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.ClientPages.Cart;

public partial class CartPageUC : UserControl
{
    private CartItemHandler cartItemHandler = CartItemHandler.GetInstance();
    private List<CartItemDto> cartItems = new List<CartItemDto>();
    public CartPageUC()
    {
        InitializeComponent();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        cartItems = await cartItemHandler.GetCartItems();
        cartItemListView.ItemsSource = cartItems;
    }

    private void btnCheckout_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}