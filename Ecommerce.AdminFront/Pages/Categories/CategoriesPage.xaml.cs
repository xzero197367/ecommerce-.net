
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.DTOs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Categories
{
    /// <summary>
    /// Lógica de interacción para Dashboard.xaml
    /// </summary>
    public partial class CategoriesPage : Page
    {
        private CategoryHandler categoryHandler;
        public CategoriesPage()
        {
            categoryHandler = new CategoryHandler();
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            categoryForm.AfterSaveAction += refreshCategories;
            refreshCategories();
        }

        public async void refreshCategories()
        {
            var list = await categoryHandler.GetCategories();
            categoryTable.categoryListView.DataContext = list;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;
        }

        // Close popover when the close button is clicked
        private void ClosePopover(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = false;
        }

      
    }
}
