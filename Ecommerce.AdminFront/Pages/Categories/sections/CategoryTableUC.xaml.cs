
using Ecommerce.DTOs;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    /// <summary>
    /// Interaction logic for CategoryTableUC.xaml
    /// </summary>
    public partial class CategoryTableUC : UserControl
    {
        public ObservableCollection<CategoryDto> Categories { get; set; }

        public CategoryTableUC()
        {
            InitializeComponent();
            Categories = new ObservableCollection<CategoryDto>
            {
                new CategoryDto
                {
                    CategoryId = 1,
                    Name = "Electronics",
                    Description = "Electronic gadgets and devices.",
                    Products = new List<ProductDto>
                    {
                        new ProductDto(), new ProductDto() // dummy products
                    }
                },
                new CategoryDto
                {
                    CategoryId = 2,
                    Name = "Books",
                    Description = "All kinds of books.",
                    Products = new List<ProductDto>() // empty
                }
            };

            DataContext = this;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
