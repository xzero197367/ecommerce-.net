
using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.AdminFront.Pages.Home;
using Wpf.Ui.Appearance;

namespace Ecommerce.AdminFront.Pages
{
    /// <summary>
    /// Interaction logic for DashboardLayoutUC.xaml
    /// </summary>
    public partial class DashboardLayoutUC : UserControl
    {
        private LandingPageUC landingPage; 
        public DashboardLayoutUC()
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

        private void DashboardLayoutUC_OnLoaded(object sender, RoutedEventArgs e)
        {
            //RootFrame.Navigate(typeof(HomeUC));
        }

        private void show_user_view(object sender, RoutedEventArgs e)
        {
            MainWindowEntry.MainGrid.Children.Clear();
            landingPage = new LandingPageUC();
            MainWindowEntry.MainGrid.Children.Add(landingPage);
        }
    }
}
