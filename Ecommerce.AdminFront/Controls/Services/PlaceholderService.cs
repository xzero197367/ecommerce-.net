using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;


namespace Ecommerce.AdminFront.Controls.Services
{

    public static class PlaceholderService
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(PlaceholderService),
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
            if (d is TextBox textBox)
            {
                textBox.Loaded += (s, ev) => AddPlaceholder(textBox);
                textBox.TextChanged += (s, ev) => AddPlaceholder(textBox);
            }
        }

        private static void AddPlaceholder(TextBox textBox)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(textBox);
            if (adornerLayer == null)
                return;

            var existingAdorner = GetPlaceholderAdorner(textBox, adornerLayer);

            if (string.IsNullOrEmpty(textBox.Text) && !textBox.IsFocused)
            {
                if (existingAdorner == null)
                {
                    adornerLayer.Add(new PlaceholderAdorner(textBox, GetPlaceholder(textBox)));
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

        private static Adorner GetPlaceholderAdorner(TextBox textBox, AdornerLayer adornerLayer)
        {
            var adorners = adornerLayer.GetAdorners(textBox);
            if (adorners == null)
                return null;

            foreach (var adorner in adorners)
            {
                if (adorner is PlaceholderAdorner)
                    return adorner;
            }

            return null;
        }

    }

}
