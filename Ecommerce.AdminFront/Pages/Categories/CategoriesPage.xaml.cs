
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.DTOs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WPFModernVerticalMenu.Pages.Categories
{
    
    public partial class CategoriesPage : Page
    {
        private CategoryHandler categoryHandler;
        private ObservableCollection<CategoryDto> categories;
        public CategoriesPage()
        {
            categoryHandler = CategoryHandler.GetInstance();
            InitializeComponent();
            
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            categoryForm.AfterSaveAction = refreshCategories;
            categoryTable.OnUpdateCategory = categoryHandler.onUpdateCategory;

            categoryTable.RefreshCategories = refreshCategories;

            categoryForm.onSaveAction = async (dto) =>
            {
                var res = await categoryHandler.CreateCategory(dto);
                return res;
            };
            categoryTable.OnDeleteCategory = async (id) =>
            {
                var res = await categoryHandler.DeleteCategory(id);
                return res;
            };
            
            await refreshCategories();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

       

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            categoryTable.categoryListView.DataContext = categories
                .Where(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                .ToList();
        }

        public async Task refreshCategories()
        {
            PopoverPopup.IsOpen = false;
            PopoverPopup.StaysOpen = false;
            var items = await categoryHandler.GetCategories();
            categories = new ObservableCollection<CategoryDto>(items);
            categoryTable.categoryListView.ItemsSource = categories;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = true;
            PopoverPopup.StaysOpen = true;
        }

        // Close popover when the close button is clicked
        private void ClosePopover(object sender, RoutedEventArgs e)
        {
            PopoverPopup.IsOpen = false;
            PopoverPopup.StaysOpen = false;
        }

      
    }
}
