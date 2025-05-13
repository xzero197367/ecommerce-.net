using Ecommerce.AdminFront.Pages.CartItems;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Cart;

public partial class CartPageUC : UserControl
{
    private CartItemHandler cartItemHandler;
    public CartPageUC()
    {
        InitializeComponent();
    }

    private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {

    }
}