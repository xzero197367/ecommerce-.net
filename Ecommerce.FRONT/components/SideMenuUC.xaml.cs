using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Ecommerce.FRONT.components;

public partial class SideMenuUC : UserControl
{
    private readonly double _expandedWidth = 200;
        private readonly double _collapsedWidth = 50;
        private bool _isExpanded = true;

        public SideMenuUC()
        {
            InitializeComponent();
            DataContext = this;
        }

        public object CurrentPage { get; set; } = new object(); // Placeholder for navigation

        private void ToggleSidebarButton_Checked(object sender, RoutedEventArgs e)
        {
            ExpandSidebar();
        }

        private void ToggleSidebarButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CollapseSidebar();
        }

        private void ExpandSidebar()
        {
            if (!_isExpanded)
            {
                _isExpanded = true;
                var animation = new DoubleAnimation()
                {
                    To = _expandedWidth,
                    Duration = TimeSpan.FromSeconds(0.3),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Sidebar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                SidebarColumn.Width = new GridLength(_expandedWidth);
            }
        }

        private void CollapseSidebar()
        {
            if (_isExpanded)
            {
                _isExpanded = false;
                var animation = new DoubleAnimation
                {
                    To = _collapsedWidth,
                    Duration = TimeSpan.FromSeconds(0.3),
                    EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseOut }
                };
                Sidebar.BeginAnimation(FrameworkElement.WidthProperty, animation);
                SidebarColumn.Width = new GridLength(_collapsedWidth);
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                MessageBox.Show($"Navigating to {button.Content}");
                // Add navigation logic here (e.g., update CurrentPage)
            }
        }
}