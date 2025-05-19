using Ecommerce.DTOs;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Components
{
    public partial class OrderDetailCardUC : UserControl, INotifyPropertyChanged
    {


        public OrderDetailDto Detail
        {
            get { return (OrderDetailDto)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        public static readonly DependencyProperty DetailProperty =
            DependencyProperty.Register("Detail", typeof(OrderDetailDto), typeof(OrderDetailCardUC), new PropertyMetadata(null));





        public string TotalPrice
        {
            get { return (string)GetValue(TotalPriceProperty); }
            set { SetValue(TotalPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TotalPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalPriceProperty =
            DependencyProperty.Register("TotalPrice", typeof(string), typeof(OrderDetailCardUC), new PropertyMetadata(null));



        public OrderDetailCardUC()
        {
            InitializeComponent();
        }

    

        private void UpdateFromDetail()
        {
            productCardUC.btnAddToCart.Visibility = Visibility.Collapsed;
            if (Detail == null || Detail.Product == null) return;
            TotalPrice = (Detail.Quantity * Detail.Product.Price).ToString("F2");
            lblTotalPrice.Text = TotalPrice;
            txtQty.Text = Detail.Quantity.ToString();
            productCardUC.Product = Detail.Product;
            DataContext = Detail;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateFromDetail();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
