using System.Windows.Controls;
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
        categoryHandler = CategoryHandler.GetInstance();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var categories = await categoryHandler.GetCategories();
        categoryListView.ItemsSource = categories;
    }
}
