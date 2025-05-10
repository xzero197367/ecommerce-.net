using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Components;

public partial class CartCardUC : UserControl
{
    private int _quantity = 1; // Default quantity
    private double _price = 99.99; // Product price
    
    public CartCardUC()
    {
        InitializeComponent();
    }
    
    // Increase quantity
    private void IncreaseQty_Click(object sender, RoutedEventArgs e)
    {
        _quantity++;
        QuantityText.Text = _quantity.ToString();
        UpdateTotalPrice();
    }

    // Decrease quantity
    private void DecreaseQty_Click(object sender, RoutedEventArgs e)
    {
        if (_quantity > 1)
        {
            _quantity--;
            QuantityText.Text = _quantity.ToString();
            UpdateTotalPrice();
        }
    }

    // Update total price based on quantity
    private void UpdateTotalPrice()
    {
        double totalPrice = _quantity * _price;
        // Update the displayed total price (in the bottom TextBlock)
        txtTotalPrice.Text = $"${totalPrice:0.00}";
    }
}