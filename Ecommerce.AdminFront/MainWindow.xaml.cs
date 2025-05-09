using Ecommerce.AdminFront;
using Ecommerce.AdminFront.Pages.Auth;
using Ecommerce.Application.Mapping;
using Ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFModernVerticalMenu
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PopupWindow popupWindow;    

        public static MainWindow Instance { get; set; }
        public static UserDto currentUser { get; set; }

        public MainWindow()
        {
            Instance = this;
            if (currentUser is null)
            {
                showLoginWindow();
            }
            InitializeComponent();
            MappesterConfig.Congfigure();
            //showRegisterWindow();
           

        }

        private void showLoginWindow()
        {
            LoginPageUC loginPageUC = new LoginPageUC();
            PopupWindow popupWindow = new PopupWindow();
            popupWindow.containerGrid.Children.Add(loginPageUC);
            popupWindow.Show();
            this.Close();
        }

        private void showRegisterWindow()
        {
            RegisterPageUC registerPage = new RegisterPageUC();
            popupWindow = new PopupWindow();
            popupWindow.containerGrid.Children.Add(registerPage);
            popupWindow.SizeToContent = SizeToContent.WidthAndHeight;
           
            popupWindow.Show();
            this.Close();
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void MenuButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false && sender is Button btn && btn.Tag is string tag)
            {
                Popup.PlacementTarget = btn;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = tag.Split("/")[0];
            }
        }

        private void MenuButton_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is string tag)
            {
                string pageName = tag.Replace(" ", string.Empty); // e.g. "Product Stock" -> "ProductStock"
                string pagePath = $"Pages/{pageName}.xaml";

                try
                {
                    fContainer.Navigate(new Uri(pagePath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load page: {pagePath}\n{ex.Message}", "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }



       
        // End: MenuLeft PopupButton //

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

      
    }
}
