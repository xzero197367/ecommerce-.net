
using System.Windows;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Users
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;
        }

        // Close popover when the close button is clicked
        private void ClosePopover(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = false;
        }
    }
}
