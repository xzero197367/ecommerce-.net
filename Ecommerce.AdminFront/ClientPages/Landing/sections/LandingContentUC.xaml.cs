using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.AdminFront.Pages.Products;
using Ecommerce.Application.Services.Pages;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class LandingContentUC : UserControl
{
    private readonly LandingPageServices landingPageServices;
    private readonly CategoryHandler categoryHandler;
    private readonly ProductHandler productHandler;
    public LandingContentUC()
    {
        InitializeComponent();
        productHandler = ProductHandler.GetInstance();
        categoryHandler = CategoryHandler.GetInstance();
        landingPageServices = new LandingPageServices(categoryHandler.CategoryService, productHandler.ProductService);
    }

    private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
        var data = await landingPageServices.GetLandingPageData();
        categorySection.categoryListView.DataContext = data.Categories;
        productSection.productsListView.DataContext = data.Products;
    }
}