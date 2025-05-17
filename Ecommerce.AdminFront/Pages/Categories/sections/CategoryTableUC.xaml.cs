

using Ecommerce.DTOs;
using Mapster;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    public partial class CategoryTableUC : UserControl
    {
        public Func<Task> RefreshCategories { get; set; } = () => Task.CompletedTask;
        public Func<int, Task<(bool status, string message)>> OnDeleteCategory { get; set; } = (id) => Task.FromResult((false, "Error occurred while deleting the category. Please try again later."));

        public Func<CategoryDto, Task<(bool status, string message)>> OnUpdateCategory { get; set; } = (dto) => Task.FromResult((false, "Error occurred while updating from table the category. Please try again later."));

        private PopupWindow popupWindow;
        private CategoryFromUC categoryFrom;

        public CategoryTableUC()

        {
            InitializeComponent();
           

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void delete_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            if (MessageBox.Show("Are you sure deleting this user", "Delete User", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                var res = await OnDeleteCategory.Invoke(category.CategoryId);
                //MessageBox.Show(res.message);
                await RefreshCategories.Invoke();
            }
        }

        private async void edit_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            popupWindow = new PopupWindow();
            categoryFrom = new CategoryFromUC() { 
                onSaveAction = async delegate (CategoryDto dto) {
                    var res =  await OnUpdateCategory(dto);
                    popupWindow.Close();
                    return res;
                }, 
                categoryCreateDto = category,
            };
            categoryFrom.btnSave.Content = "Update";
            popupWindow.containerGrid.Children.Add(categoryFrom);
            popupWindow.SizeToContent = SizeToContent.WidthAndHeight;
            popupWindow.ShowDialog();
            await RefreshCategories.Invoke();
        }

       
    }
}
