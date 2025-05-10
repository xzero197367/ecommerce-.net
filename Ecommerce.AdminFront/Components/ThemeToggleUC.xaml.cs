using System.Windows;
using System.Windows.Controls;
using Wpf.Ui.Appearance;

namespace Ecommerce.AdminFront.Components;

public partial class ThemeToggleUC : UserControl
{
    public ThemeToggleUC()
    {
        InitializeComponent();
    }

    private void change_theme_click(object sender, RoutedEventArgs e)
    {
        ApplicationTheme currentTheme = ApplicationThemeManager.GetAppTheme();

        ApplicationThemeManager.Apply(
            currentTheme == ApplicationTheme.Light
                ? ApplicationTheme.Dark
                : ApplicationTheme.Light
        );
    }
}