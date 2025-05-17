using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.ClientPages.Product;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.DTOs;
using WPFModernVerticalMenu.Pages.Products;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class CategorySection : UserControl
{
    private CategoryHandler categoryHandler;
    private ClientProductsPage productsPage;
    public CategorySection()
    {
        InitializeComponent();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        categoryListView.SelectionChanged += CategoryListView_SelectionChanged;
    }

    private void CategoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(categoryListView.SelectedItem is CategoryDto category)
        {
            productsPage = new ClientProductsPage() { CategoryId = category.CategoryId };
            LandingPageUC.BodyGrid.Children.Clear();
            LandingPageUC.BodyGrid.Children.Add(productsPage);
        }
    }

    // Attach this event handler to your horizontal ListView
    private void HorizontalListView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var listView = sender as ListView;
        var scrollViewer = FindParentScrollViewer(listView);

        if (scrollViewer != null)
        {
            // Scroll the parent ScrollViewer vertically
            if (e.Delta != 0)
            {
                scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta);
                e.Handled = true; // Mark event as handled so ListView doesn't consume it
            }
        }
    }

    private ScrollViewer FindParentScrollViewer(DependencyObject child)
    {
        DependencyObject parent = VisualTreeHelper.GetParent(child);
        while (parent != null && !(parent is ScrollViewer))
        {
            parent = VisualTreeHelper.GetParent(parent);
        }
        return parent as ScrollViewer;
    }

}
