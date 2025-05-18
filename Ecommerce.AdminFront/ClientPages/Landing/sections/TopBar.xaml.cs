using System.Windows;
using System.Windows.Controls;
using Ecommerce.AdminFront.ClientPages.Cart;
using Ecommerce.AdminFront.ClientPages.Order;
using Ecommerce.AdminFront.ClientPages.Profile;
using Ecommerce.AdminFront.ClientPages.Settings;
using Ecommerce.AdminFront.Components;
using Ecommerce.AdminFront.Pages;
using Ecommerce.AdminFront.Pages.Auth;
using Ecommerce.AdminFront.Pages.Users;
using Ecommerce.DTOs;
using Ecommerce.Models;

namespace Ecommerce.AdminFront.ClientPages.Landing.sections;

public partial class TopBar : UserControl
{
    private DashboardLayoutUC dashboard;
    private PopoverUC popover;
    public static TopBar Instance { get; private set; } = null;
    private UserHandler userHandler;
    private AuthHandler authHandler = AuthHandler.Instance;

    private UIElement page;
    
    public TopBar()
    {
       userHandler = UserHandler.GetInstance();
        InitializeComponent();
        Instance = this;
    }

    private void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        profilePopup.popup = popup;
        
        if (MainWindowEntry.currentUser != null)
        {
            if(MainWindowEntry.currentUser.UserRole == UserRole.Admin) btnDashboard.Visibility = Visibility.Visible;
            authStack.Visibility = Visibility.Collapsed;
            btnUserPopup.Visibility = Visibility.Visible;
        }
        else
        {
            authStack.Visibility = Visibility.Visible;
            btnUserPopup.Visibility = Visibility.Collapsed;
        }
        if(MainWindowEntry.currentUser != null) {
            authHandler.CheckUiVisibile(MainWindowEntry.currentUser);
        }
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

    public void BtnHomeIcon_OnClick(object sender, RoutedEventArgs e)
    {
        switch ((sender as Control)!.Tag)
        {
            case "Home":
                page = new LandingContentUC();
                break;
            case "Cart":
                page = new CartPageUC();
                break;
            case "Order":
                page = new OrdersClientPage();
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
            case "LogOut":
                 authHandler.Logout();
                return;
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

    private void btnUserPopup_Click(object sender, RoutedEventArgs e)
    {
        if (popup.IsOpen)
        {
            // popup.StaysOpen = false;
            popup.IsOpen = false;
            if (profilePopup.OnSaveAction == null)
            {
                profilePopup.OnSaveAction += async (dto) =>
                {
                    UserDto user = dto;
                    user.UserID = MainWindowEntry.currentUser.UserID;
                    var res = await userHandler.onUpdateUser(user);
                    return res;
                };
            }
        }
        else
        {
            popup.IsOpen = true;
            // popup.StaysOpen = true;
        }
    }
}