
using Ecommerce.AdminFront;
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
        private List<CategoryDto> categories = new List<CategoryDto>();
        public CategoriesPage()
        {
            categoryHandler = CategoryHandler.GetInstance();
            InitializeComponent();
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            categoryForm.AfterSaveAction = refreshCategories;
            categoryTable.OnUpdateCategory += categoryHandler.onUpdateCategory;

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
            
            refreshCategories();

            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

       

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            categoryTable.categoryListView.DataContext = categories
                .Where(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower()))
                .ToList();
        }

        public async void refreshCategories()
        {
            categories = await categoryHandler.GetCategories();
            categoryTable.categoryListView.DataContext = categories;
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
