using Ecommerce.DTOs;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Ecommerce.AdminFront.Components
{
    public partial class OrderDetailCardUC : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty DetailProperty =
          DependencyProperty.Register(nameof(Detail), typeof(OrderDetailDto), typeof(OrderDetailCardUC),
              new PropertyMetadata(null, OnDetailChanged));

        public OrderDetailDto Detail
        {
            get => (OrderDetailDto)GetValue(DetailProperty);
            set => SetValue(DetailProperty, value);
        }

        private string _totalPrice;
        public string TotalPrice
        {
            get => _totalPrice;
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public OrderDetailCardUC()
        {
            InitializeComponent();
        }

        private static void OnDetailChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as OrderDetailCardUC;
            control?.UpdateFromDetail();
        }

        private void UpdateFromDetail()
        {
            productCardUC.btnAddToCart.Visibility = Visibility.Collapsed;
            if (Detail == null || Detail.Product == null) return;
            TotalPrice = (Detail.Quantity * Detail.Product.Price).ToString("F2");
            if (productCardUC != null)
            {
                productCardUC.Product = Detail.Product;
             
            }
            DataContext = this;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateFromDetail();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
