using System.Windows.Controls;
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class CategorySection : UserControl
{
    public CategorySection()
    {
        InitializeComponent();
        var container = AutoFac.Inject(); 
        var categoryService = container.Resolve<ICategoryServices>();
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var container = AutoFac.Inject();

        var categoryService = container.Resolve<ICategoryServices>();

        var categories = await categoryService.GetCategoriesAsync();
        categoryListView.ItemsSource = categories;
    }
}
