using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Ecommerce.AdminFront.Controls;

public partial class CustomTextbox : UserControl
{
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(CustomTextbox),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

    public static readonly DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register("PlaceholderText", typeof(string), typeof(CustomTextbox),
            new PropertyMetadata(string.Empty));

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public string PlaceholderTextValue
    {
        get { return (string)GetValue(PlaceholderTextProperty); }
        set { SetValue(PlaceholderTextProperty, value); }
    }

    public CustomTextbox()
    {
        InitializeComponent();
    }

    private void InnerTextBox_GotFocus(object sender, RoutedEventArgs e)
    {
        UpdatePlaceholderAnimation();
    }

    private void InnerTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        UpdatePlaceholderAnimation();
    }

    private void InnerTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdatePlaceholderAnimation();
    }

    private void UpdatePlaceholderAnimation()
    {
        var focusIn = (Storyboard)Resources["PlaceholderFocusIn"];
        var focusOut = (Storyboard)Resources["PlaceholderFocusOut"];

        if (InnerTextBox.IsFocused || !string.IsNullOrEmpty(InnerTextBox.Text))
        {
            PlaceholderText.Visibility = Visibility.Visible;
            focusIn.Begin();
        }
        else
        {
            focusOut.Begin();
            PlaceholderText.Visibility =
                string.IsNullOrEmpty(PlaceholderText.Text) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}