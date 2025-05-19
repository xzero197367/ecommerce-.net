using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.Pages.CartItems;

namespace Ecommerce.AdminFront.Components;

public partial class CartCardUC : UserControl
{
 

    public Action OnRefreshAction
    {
        get { return (Action)GetValue(OnRefreshActionProperty); }
        set { SetValue(OnRefreshActionProperty, value); }
    }

    public static readonly DependencyProperty OnRefreshActionProperty =
        DependencyProperty.Register("OnRefreshAction", typeof(Action), typeof(CartCardUC), new PropertyMetadata(null));



    private CartItemHandler cartItemHandler = CartItemHandler.GetInstance();

    public CartItemDto CartItem
    {
        get { return (CartItemDto)GetValue(CartItemProperty); }
        set { SetValue(CartItemProperty, value); }
    }

    public static readonly DependencyProperty CartItemProperty =
        DependencyProperty.Register("CartItem", typeof(CartItemDto), typeof(CartCardUC), new PropertyMetadata(null));



    public CartCardUC()
    {
        InitializeComponent();
    }


    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        QuantityText.Text = CartItem.Quantity.ToString();
        UpdateTotalPrice();
    }

    // Increase quantity
    private async void IncreaseQty_Click(object sender, RoutedEventArgs e)
    {
        if(CartItem.Quantity >= CartItem.Product.UnitsInStock) return;
        CartItem.Quantity++;
        await cartItemHandler.onUpdateCartItem(
            CartItem
        );
        QuantityText.Text = CartItem.Quantity.ToString();
        UpdateTotalPrice();
    }

    // Decrease quantity
    private async void DecreaseQty_Click(object sender, RoutedEventArgs e)
    {
        if (CartItem.Quantity > 1)
        {
            await cartItemHandler.onUpdateCartItem(
                CartItem
            );
            CartItem.Quantity--;
            QuantityText.Text = CartItem.Quantity.ToString();
            UpdateTotalPrice();
        }
    }

    // Update total price based on quantity
    private async void UpdateTotalPrice()
    {
        double totalPrice = Convert.ToDouble(CartItem.Quantity * CartItem.Product.Price);

        // Update the displayed total price (in the bottom TextBlock)
        txtTotalPrice.Text = $"${totalPrice:0.00}";
    }

    private async void BtnRemove_OnClick(object sender, RoutedEventArgs e)
    {
        await cartItemHandler.DeleteCartItem(CartItem.CartItemID);
        MainWindowEntry.cartItems = await cartItemHandler.GetCartItems();
        OnRefreshAction?.Invoke();
    }

   
}