
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ecommerce.FRONT.components
{
    
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ImagePath { get; set; }
    }

    public partial class ProductCardUC : UserControl
    {
        public ProductCardUC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", 
                typeof(Product), 
                typeof(ProductCardUC), 
                new PropertyMetadata(null));

        public Product Product
        {
            get => (Product)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }

        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register("ClickCommand", typeof(ICommand), typeof(ProductCardUC), new PropertyMetadata(null));

        public ICommand ClickCommand
        {
            get => (ICommand)GetValue(ClickCommandProperty);
            set => SetValue(ClickCommandProperty, value);
        }

    }
}
