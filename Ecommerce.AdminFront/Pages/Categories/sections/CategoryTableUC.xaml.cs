

using Ecommerce.DTOs;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    /// <summary>
    /// Interaction logic for CategoryTableUC.xaml
    /// </summary>
    public partial class CategoryTableUC : UserControl
    {
        public Action RefreshCategories { get; set; } = ()=> { };
        private CategoryHandler categoryHandler;
       

        public CategoryTableUC()

        {
            categoryHandler = new CategoryHandler();
            InitializeComponent();
           

        }

        private async void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            //var list = await categoryHandler.GetCategories();
            //Categories = new ObservableCollection<CategoryDto>(list);
            //DataContext = this;
        }

        private async void delete_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            var res = await categoryHandler.DeleteCategory(category.CategoryId);
            MessageBox.Show(res.message);
            RefreshCategories();
        }

        private void edit_category_click(object sender, System.Windows.RoutedEventArgs e)
        {
            CategoryDto category = ((sender as Button).DataContext as CategoryDto)!;
            
        }
    }
}
