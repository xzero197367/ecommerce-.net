
using Ecommerce.AdminFront.Pages.Products;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Ecommerce.AdminFront.ClientPages.Product;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class ProductSection : UserControl
{
    private ProductHandler productHandler;
    private ClientProductsPage productsPage;
    public ProductSection()
    {
        InitializeComponent();
        //productHandler = ProductHandler.GetInstance();
    }


    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        //productsListView.DataContext = await productHandler.GetProducts();
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


    private void BtnMore_OnClick(object sender, RoutedEventArgs e)
    {
        productsPage = new ClientProductsPage();
        LandingPageUC.BodyGrid.Children.Clear();
        LandingPageUC.BodyGrid.Children.Add(productsPage);
    }
}