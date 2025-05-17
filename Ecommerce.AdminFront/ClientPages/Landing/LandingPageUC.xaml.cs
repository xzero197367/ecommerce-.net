using Ecommerce.AdminFront.Pages.Auth;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Ecommerce.AdminFront.ClientPages.Landing;

public partial class LandingPageUC : UserControl
{
 
    public static Grid BodyGrid { get; set; }
    private AuthHandler authHandler = AuthHandler.Instance;

    public LandingPageUC()
    {
        InitializeComponent();
        BodyGrid = bodyGrid;
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        
    }
}