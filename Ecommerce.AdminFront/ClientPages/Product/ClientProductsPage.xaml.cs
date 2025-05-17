using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.AdminFront.Pages.Products;
using Ecommerce.DTOs;
using Wpf.Ui.Controls;

namespace Ecommerce.AdminFront.ClientPages.Product;

public partial class ClientProductsPage : UserControl
{
    public int CategoryId { get; set; } = -1;
    private ProductHandler productHandler = ProductHandler.GetInstance();
    private CategoryHandler categoryHandler = CategoryHandler.GetInstance();
    private List<ProductDto> products = new List<ProductDto>();
    public ClientProductsPage()
    {
        InitializeComponent();
    }

    private async void ProductsPage_OnLoaded(object sender, RoutedEventArgs e)
    {
        products = await productHandler.GetProducts();
        productsListView.ItemsSource = products;
        var categories = await categoryHandler.GetCategories();
        categoryComboBox.ItemsSource = categories;
        categoryComboBox.DisplayMemberPath = "Name";
        categoryComboBox.SelectedValuePath = "CategoryId";
        categoryComboBox.SelectionChanged += CategoryComboBox_SelectionChanged;
        if(CategoryId != -1)
        {
            categoryComboBox.SelectedIndex = categories.IndexOf(categories.First(x => x.CategoryId == CategoryId));
        }
    }

    private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(categoryComboBox.SelectedIndex != -1)
        {
           productsListView.ItemsSource = products.Where(x => x.CategoryID == (int)categoryComboBox.SelectedValue);
        }
        else
        {
            productsListView.ItemsSource = products;
        }
    }

    private void FilterProducts_OnTextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
    {
        productsListView.ItemsSource = products.Where(x => x.Name.ToLower().Contains(sender.Text.ToLower()));
    }
}