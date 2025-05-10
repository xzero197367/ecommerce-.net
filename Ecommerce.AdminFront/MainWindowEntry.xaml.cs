using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Landing;

namespace Ecommerce.AdminFront;

public partial class MainWindowEntry : Window
{
    public static Grid MainGrid { get; private set; }
    public MainWindowEntry()
    {
        InitializeComponent();
        MainGrid = mainGrid;
        
    }
}