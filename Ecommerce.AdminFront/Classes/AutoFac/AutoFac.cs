using Autofac;
using Ecommerce.Application.Contracts;
using Ecommerce.Application.Services.CartItemServices;
using Ecommerce.Application.Services.CategoryServices;
using Ecommerce.Application.Services.OrderServices;
using Ecommerce.Application.Services.Pages;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Context;
using Ecommerce.Infrastructure;
using Ecommerce.Models;

namespace Ecommerce.AdminFront.Classes.AutoFac
{
    public class AutoFac
    {
        public static IContainer Inject()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ContextDB>().As<ContextDB>();
            
            builder.RegisterType<UserRepo>().As<IUserRepo>();
            builder.RegisterType<UserServices>().As<IUserServices>();
            
            builder.RegisterType<ProductRepo>().As<IProductRepo>();
            builder.RegisterType<ProductServices>().As<IProductServices>();
            
            builder.RegisterGeneric(typeof(GenericRepo<>)).As(typeof(IGenericRepo<>));
            
            builder.RegisterType<CategoryRepo>().As<ICategoryRepo>();
            builder.RegisterType<CategoryServices>().As<ICategoryServices>();

            builder.RegisterType<LandingPageServices>().As<LandingPageServices>();

            builder.RegisterType<OrderRepo>().As<IOrderRepo>();
            builder.RegisterType<OrderServices>().As<IOrderServices>();
            
            builder.RegisterType<CartItemRepo>().As<ICartItemRepo>();
            builder.RegisterType<CartItemServices>().As<ICartItemServices>();

            return builder.Build();
        }
    }
}
