using Ecommerce.AdminFront.ClientPages.Landing.sections;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.DTOs;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.AdminFront.Classes.AutoFac;
using Autofac;
using System.Windows;
using Ecommerce.Models;
using Ecommerce.AdminFront.Pages.CartItems;

namespace Ecommerce.AdminFront.Pages.Auth
{
    class AuthHandler
    {
        private readonly IUserServices userServices;
        private LandingContentUC landingContentUC;
        private CartItemHandler cartItemHandler = CartItemHandler.GetInstance();

        public static AuthHandler Instance { get; } = new AuthHandler();

        private AuthHandler()
        {
            var container = AutoFac.Inject();
            userServices = container.Resolve<IUserServices>();
        }

        public async Task<UserDto?> LoginAsync(string username, string password)
        {
            return await userServices.LoginAsync(username, password);
        }

        public async Task<UserDto> RegisterAsync(UserDto newUser)
        {
            return await userServices.RegisterAsync(newUser);
        }

        public void CheckUiVisibile(UserDto user)
        {
            TopBar.Instance.authStack.Visibility = Visibility.Collapsed;
            TopBar.Instance.btnUserPopup.Visibility = Visibility.Visible;
            TopBar.Instance.logOutMenuItem.Visibility = Visibility.Visible;
            TopBar.Instance.profileMenuItem.Visibility = Visibility.Visible;
            TopBar.Instance.settingMenuItem.Visibility = Visibility.Visible;
            TopBar.Instance.cartMenuItem.Visibility = Visibility.Visible;
            TopBar.Instance.orderMenuItem.Visibility = Visibility.Visible;
            TopBar.Instance.profilePopup.User = MainWindowEntry.currentUser;
            if (user.UserRole == UserRole.Admin) TopBar.Instance.btnDashboard.Visibility = Visibility.Visible;
        }

        public async void AfterAuth(UserDto user)
        {
            MainWindowEntry.currentUser = user;
            landingContentUC = new LandingContentUC();
            CheckUiVisibile(user);
            LandingPageUC.BodyGrid.Children.Clear();
            LandingPageUC.BodyGrid.Children.Add(landingContentUC);
            MainWindowEntry.cartItems = await cartItemHandler.GetCartItems();
        }
        
        public void Logout()
        {
            MainWindowEntry.currentUser = null;
            MainWindowEntry.cartItems = null;
            //TopBar.Instance.authStack.Visibility = Visibility.Visible;
            //TopBar.Instance.btnUserPopup.Visibility = Visibility.Collapsed;
            //TopBar.Instance.btnDashboard.Visibility = Visibility.Collapsed;
            //TopBar.Instance.logOutMenuItem.Visibility = Visibility.Collapsed;
            //TopBar.Instance.profileMenuItem.Visibility = Visibility.Collapsed;
            //TopBar.Instance.settingMenuItem.Visibility = Visibility.Collapsed;
            //TopBar.Instance.cartMenuItem.Visibility = Visibility.Collapsed;
            MainWindowEntry.MainGrid.Children.Clear();
            MainWindowEntry.MainGrid.Children.Add(new LandingPageUC());
        }
    }
}