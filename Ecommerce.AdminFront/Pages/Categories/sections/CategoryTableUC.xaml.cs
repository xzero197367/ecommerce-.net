
using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Context;
using Ecommerce.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Pages.Categories.sections
{
    /// <summary>
    /// Interaction logic for CategoryTableUC.xaml
    /// </summary>
    public partial class CategoryTableUC : UserControl
    {
        
        private readonly ICategoryServices _categoryService;

        
        public ObservableCollection<CategoryDto> Categories { get; set; }



        public CategoryTableUC()

        {
            InitializeComponent();
            


            var container = AutoFac.Inject();
            _categoryService = container.Resolve<ICategoryServices>();

            Categories = new ObservableCollection<CategoryDto>();

            //Categories = new ObservableCollection<CategoryDto>
            // {
            //     new CategoryDto
            //     {
            //         CategoryId = 1,
            //         Name = "Electronics",
            //         Description = "Electronic gadgets and devices.",
            //         Products = new List<ProductDto>
            //         {
            //             new ProductDto(), new ProductDto() // dummy products
            //         }
            //     },
            //     new CategoryDto
            //     {
            //         CategoryId = 2,
            //         Name = "Books",
            //         Description = "All kinds of books.",
            //         Products = new List<ProductDto>() // empty
            //     }
            // };

            //DataContext = this;

        }

            

        public async void LoadCategories()
        {
            var categoriesFromDb = await _categoryService.GetCategoriesAsync();
            foreach (var category in categoriesFromDb)
            {
                Categories.Add(category);
            }

           // DataContext = this; 
        }


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
