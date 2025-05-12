using System.Windows;
using System.Windows.Controls;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront.Components;

public partial class CategoryCardUC : UserControl
{


    public CategoryDto Category
    {
        get { return (CategoryDto)GetValue(CategoryProperty); }
        set { SetValue(CategoryProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Category.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty CategoryProperty =
        DependencyProperty.Register("Category", typeof(CategoryDto), typeof(CategoryCardUC), new PropertyMetadata(null));


    public CategoryCardUC()
    {
        InitializeComponent();
    }
}