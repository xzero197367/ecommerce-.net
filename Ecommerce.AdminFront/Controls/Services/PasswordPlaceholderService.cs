
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows;

namespace Ecommerce.AdminFront.Controls.Services
{
    public static class PasswordPlaceholderService
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(PasswordPlaceholderService),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static void SetPlaceholder(UIElement element, string value)
        {
            element.SetValue(PlaceholderProperty, value);
        }

        public static string GetPlaceholder(UIElement element)
        {
            return (string)element.GetValue(PlaceholderProperty);
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.Loaded += (_, __) => UpdatePlaceholder(passwordBox);
                passwordBox.PasswordChanged += (_, __) => UpdatePlaceholder(passwordBox);
            }
        }

        private static void UpdatePlaceholder(PasswordBox passwordBox)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(passwordBox);
            if (adornerLayer == null) return;

            bool isEmpty = string.IsNullOrEmpty(passwordBox.Password);
            var adorners = adornerLayer.GetAdorners(passwordBox);
            var existingAdorner = adorners?.FirstOrDefault(a => a is PlaceholderAdorner);

            if (isEmpty)
            {
                if (existingAdorner == null)
                {
                    string placeholder = GetPlaceholder(passwordBox);
                    adornerLayer.Add(new PlaceholderAdorner(passwordBox, placeholder));
                }
            }
            else
            {
                if (existingAdorner != null)
                {
                    adornerLayer.Remove(existingAdorner);
                }
            }
        }
    }
}
