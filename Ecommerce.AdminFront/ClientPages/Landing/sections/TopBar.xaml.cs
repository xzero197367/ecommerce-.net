using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Cart;
using Ecommerce.AdminFront.ClientPages.Profile;
using Ecommerce.AdminFront.ClientPages.Settings;
using Ecommerce.AdminFront.Components;
using Ecommerce.AdminFront.Pages;
using Ecommerce.AdminFront.Pages.Auth;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class TopBar : UserControl
{
    private DashboardLayoutUC dashboard;
    private PopoverUC popover;

    private UIElement page;
    
    // private LandingContentUC landingContent;
    // private CartPageUC cartPage;
    // private ProfilePageUC profilePage;
    // private SettingPageUC settingPage;
    public TopBar()
    {
        InitializeComponent();
    }

    private void go_dashboard_btn_click(object sender, RoutedEventArgs e)
    {
        dashboard = new DashboardLayoutUC();
        try
        {
            MainWindowEntry.MainGrid.Children.RemoveAt(0);
        }catch{}
        MainWindowEntry.MainGrid.Children.Add(dashboard);
    }

    private void BtnCartIcon_OnClick(object sender, RoutedEventArgs e)
    {
        popover = new PopoverUC(onClose: () =>
        {
            MainWindowEntry.MainGrid.Children.RemoveAt(1);
        });
        popover.ContainerGrid.Children.Add(new CartPageUC());
        MainWindowEntry.MainGrid.Children.Add(popover);
    }

    private void BtnHomeIcon_OnClick(object sender, RoutedEventArgs e)
    {
        switch ((sender as Control)!.Tag)
        {
            case "Home":
                page = new LandingContentUC();
                break;
            case "Cart":
                page = new CartPageUC();
                break;
            case "Profile":
                page = new ProfilePageUC();
                break;
            case "Settings":
                page = new SettingPageUC();
                break;
            case "Login":
                page = new LoginPageUC();
                break;
            case "Register":
                page = new RegisterPageUC();
                break;
            default:
                return;
        }
        setBodyGrid(page, btnHomeIcon);
    }

    private void setBodyGrid(UIElement page, Button button)
    {
        button.IsEnabled = false;
        LandingPageUC.BodyGrid.Children.Clear();
        LandingPageUC.BodyGrid.Children.Add(page);
        button.IsEnabled = true;
    }
}