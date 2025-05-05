
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ecommerce.FRONT.components
{
    public class Category
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }

    public partial class CategoryCardUC : UserControl
    {
        public CategoryCardUC()
        {
            InitializeComponent();
        
        }
        
        public static readonly DependencyProperty CategoryProperty = 
            DependencyProperty.Register(
                "Category", typeof(Category), typeof(CategoryCardUC), new PropertyMetadata(null));
        
        public Category Category
        {
            get => (Category)DataContext;
            set => DataContext = value;
        }
        
        public static readonly DependencyProperty ClickCommandProperty =
            DependencyProperty.Register(
                "ClickCommand", 
                typeof(ICommand),
                typeof(CategoryCardUC), 
                new PropertyMetadata(null)
            );

        public ICommand ClickCommand
        {
            get => (ICommand)GetValue(ClickCommandProperty);
            set => SetValue(ClickCommandProperty, value);
        }

       

      
    }
}
