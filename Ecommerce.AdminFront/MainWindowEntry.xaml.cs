using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.Application.Mapping;
using Ecommerce.DTOs;

namespace Ecommerce.AdminFront;

public partial class MainWindowEntry : Window
{
    public static Grid MainGrid { get; private set; }
    public static UserDto currentUser { get; set; } = null;
    public MainWindowEntry()
    {
        InitializeComponent();
        MainGrid = mainGrid;
        MappesterConfig.Congfigure();
    }
}