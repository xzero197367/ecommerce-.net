using Ecommerce.AdminFront.ClientPages.Landing.sections;
using Ecommerce.AdminFront.ClientPages.Landing;
using Ecommerce.DTOs;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.AdminFront.Classes.AutoFac;
using Autofac;

namespace Ecommerce.AdminFront.Pages.Auth
{
    class AuthHandler
    {
        private readonly IUserServices userServices;
        private LandingContentUC landingContentUC;

        public AuthHandler()
        {
            var container = AutoFac.Inject();
            userServices = container.Resolve<IUserServices>();
        }

        public async Task<UserDto?> LoginAsync(string username, string password)
        {
            return await userServices.LoginAsync(username, password);
        }

        public async Task<UserDto> RegisterAsync(UserCreateDto newUser)
        {
            return await userServices.RegisterAsync(newUser);
        }

        public void AfterAuth(UserDto user)
        {
            MainWindowEntry.currentUser = user;
            landingContentUC = new LandingContentUC();
            LandingPageUC.BodyGrid.Children.Clear();
            LandingPageUC.BodyGrid.Children.Add(landingContentUC);
        }
    }
}
