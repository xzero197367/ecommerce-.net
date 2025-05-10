using System.Collections.ObjectModel;
using System.Windows;
using Wpf.Ui.Appearance;



namespace Ecommerce.AdminFront;

    

public partial class TextWindow 
{
    public ObservableCollection<string> Strings { get; } = new ObservableCollection<string>
    {
        "Home", "Section", "Page"
    };
    
    public TextWindow()
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
        // var currentTheme = ThemeManager.GetAppTheme();
        //
        // if (currentTheme == ApplicationTheme.Dark)
        //     ThemeManager.Apply(ApplicationTheme.Light);
        // else
        //     ThemeManager.Apply(ApplicationTheme.Dark);
    }
}