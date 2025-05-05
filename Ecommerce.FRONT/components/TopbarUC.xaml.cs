using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Ecommerce.FRONT.components;

public partial class TopbarUC : UserControl
{
    
    public static readonly DependencyProperty ClickCommandProperty =
        DependencyProperty.Register(
            "ClickCommand", 
            typeof(ICommand),
            typeof(TopbarUC), 
            new PropertyMetadata(null)
        );

    public ICommand ClickCommand
    {
        get => (ICommand)GetValue(ClickCommandProperty);
        set => SetValue(ClickCommandProperty, value);
    }

    public TopbarUC()
    {
        InitializeComponent();
    }
   
}