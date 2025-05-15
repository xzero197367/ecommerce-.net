using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.Application.Services.CategoryServices;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class CategorySection : UserControl
{
    private CategoryHandler categoryHandler;
    public CategorySection()
    {
        InitializeComponent();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        //var categories = await categoryHandler.GetCategories();
        //categoryListView.ItemsSource = categories;
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
