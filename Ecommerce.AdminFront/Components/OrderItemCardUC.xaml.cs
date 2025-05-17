using Ecommerce.DTOs;
using System;
using System.Collections.Generic;
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

namespace Ecommerce.AdminFront.Components
{
    /// <summary>
    /// Interaction logic for OrderItemCardUC.xaml
    /// </summary>
    public partial class OrderItemCardUC : UserControl
    {
        public OrderDto OrderDto { get; set; }

        public OrderItemCardUC()
        {
            InitializeComponent();
        }
    }
}
