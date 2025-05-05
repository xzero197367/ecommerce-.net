using Ecommerce.FRONT.classes;
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

namespace Ecommerce.FRONT.pages.client.home_page
{
    /// <summary>
    /// Interaction logic for ProductPageUC.xaml
    /// </summary>
    public partial class ProductPageUC : UserControl
    {
        public ObservableCollection<Product> Products { get; set; }
        public ICommand AddToCartCommand { get; set; }


        public ProductPageUC()
        {
            InitializeComponent();

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Book", Description = "A thrilling novel.", Price = "$19.99", ImagePath = "pack://application:,,,/res/imgs/burger.jpg"},
                new Product { Name = "Lamp", Description = "Modern desk lamp.", Price = "$29.99", ImagePath =  "pack://application:,,,/res/imgs/burger.jpg" },
                new Product { Name = "Headphones", Description = "Noise-cancelling.", Price = "$49.99", ImagePath = "pack://application:,,,/Ecommerce.FRONT;component/res/imgs/burger.jpg" }
            };

            AddToCartCommand = new RelayCommand<Product>(AddToCart);
            this.DataContext = this;

        }

        private void AddToCart(Product product)
        {
            MessageBox.Show($"Added {product.Name} to cart!");
        }


    }
}
