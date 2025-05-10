using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ecommerce.AdminFront.Components;

public partial class PopoverUC : UserControl
{
    public Action onClose;
    
    public PopoverUC(Action onClose)
    {
        this.onClose = onClose;
        InitializeComponent();
    }

    private void PopoverUC_OnLoaded(object sender, RoutedEventArgs e)
    {
        shadowBorder.MouseDown += ShadowBorderOnMouseDown;
    }

    private void ShadowBorderOnMouseDown(object sender, MouseButtonEventArgs e)
    {
        this.onClose?.Invoke();
    }
}