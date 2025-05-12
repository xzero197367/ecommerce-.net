

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

        public Func<int, CategoryCreateDto, Task<(bool status, string message)>> OnUpdateCategory { get; set; } = (id, dto) => Task.FromResult((false, "Error occurred while updating from table the category. Please try again later."));

        private PopupWindow popupWindow;
        private CategoryFromUC categoryFrom;

        public CategoryTableUC()

        {
            InitializeComponent();
           

        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void delete_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            var res = await OnDeleteCategory.Invoke(category.CategoryId);
            //MessageBox.Show(res.message);
            await RefreshCategories.Invoke();
        }

        private async void edit_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            popupWindow = new PopupWindow();
            categoryFrom = new CategoryFromUC() { 
                onSaveAction = async delegate (CategoryCreateDto dto) {
                    var res =  await OnUpdateCategory(category.CategoryId, dto);
                    popupWindow.Close();
                    return res;
                }, 
                categoryCreateDto = category.Adapt<CategoryCreateDto>(),
            };
            categoryFrom.btnSave.Content = "Update";
            popupWindow.containerGrid.Children.Add(categoryFrom);
            popupWindow.SizeToContent = SizeToContent.WidthAndHeight;
            popupWindow.ShowDialog();
            await RefreshCategories.Invoke();
        }

       
    }
}
