using Ecommerce.AdminFront.Pages.CartItems;
using System.Windows.Controls;
using Ecommerce.DTOs;
using Ecommerce.AdminFront.ClientPages.Order;

namespace Ecommerce.AdminFront.ClientPages.Cart;

public partial class CartPageUC : UserControl
{
    private CartItemHandler cartItemHandler = CartItemHandler.GetInstance();
    private OrderHandler OrderHandler = OrderHandler.Instance;
    private List<CartItemDto> cartItems = new List<CartItemDto>();
    public CartPageUC()
    {
        InitializeComponent();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        
        RefreshCartItems();
    }

    private async void RefreshCartItems()
    {
        cartItems = await cartItemHandler.GetCartItems();
        MainWindowEntry.cartItems = cartItems;
        cartItemListView.ItemsSource = cartItems;
    }

    private async void btnCheckout_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        if(cartItems == null || cartItems.Count == 0) return;
        btnCheckout.IsEnabled = false;
        await OrderHandler.CreateOrder();
        RefreshCartItems();
        btnCheckout.IsEnabled = true;
    }
}