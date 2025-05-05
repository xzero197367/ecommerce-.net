using Ecommerce.FRONT.components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ecommerce.FRONT.classes;

namespace Ecommerce.FRONT.pages.client.home_page
{
    

    public partial class CategoryPageUC : UserControl
    {
        public ObservableCollection<Category> Categories { get; set; }
        public ICommand CategoryClickCommand { get; set; }

        public CategoryPageUC()
        {
            InitializeComponent();
           
        }

      
     
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            Categories = new ObservableCollection<Category> { 
                new Category() {
                    Name = "Books",
                    Description = "A thrilling novel.",
                    ImagePath = "pack://application:,,,/res/imgs/burger.jpg"
                },
                new Category() {
                    Name = "Books",
                    Description = "A thrilling novel.",
                    ImagePath = "pack://application:,,,/res/imgs/burger.jpg"
                },
                new Category() {
                    Name = "Books",
                    Description = "A thrilling novel.",
                    ImagePath = "pack://application:,,,/res/imgs/burger.jpg"
                },
            };
            CategoryClickCommand = new RelayCommand<Category>(OnCategoryClicked);
        }

        private void OnCategoryClicked(Category category)
        {
            MessageBox.Show($"{category.Name}");
        }
    }
}
