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

        public UserDto Login(string username, string password)
        {
            return userServices.Login(username, password);
        }

        public UserDto Register(UserCreateDto newUser)
        {
            return userServices.Register(newUser);
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
