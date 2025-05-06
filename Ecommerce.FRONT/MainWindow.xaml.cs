using System.Text;
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
using Ecommerce.FRONT.pages.admin.dashboard;

namespace Ecommerce.FRONT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DashboardUC dashboardUc;
        public ICommand TopMenuCommand { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            
        }

    

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            
            TopMenuCommand = new RelayCommand<string>(NavToPage);
            DataContext = this;
        }

        private void NavToPage(string pageName)
        {
            try
            {
                mainGrid.Children.RemoveAt(0);
            }
            catch
            {
            }

            switch (pageName)
            {
                case "dashboard":
                    if (dashboardUc == null)
                    {
                        dashboardUc = new DashboardUC();
                    }
                    mainGrid.Children.Add(dashboardUc);
                    break;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}