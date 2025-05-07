using Autofac;
using Ecommerce.Application.Contracts;
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
            builder.RegisterType<UserRepo>().As<GenericRepo<User>>();
            builder.RegisterType<UserServices>().As<IUserServices>();
            //builder.RegisterType<BookServices>().As<IBookServices>();
            //builder.RegisterType<AutherRepository>().As<IAutherRepository>();
            //builder.RegisterType<AutherServices>().As<IAutherServices>();
            //builder.RegisterType<PublisherRepository>().As<IPublisherRepository>();
            //builder.RegisterType<PublisherServices>().As<IPublisherServices>();
            //builder.RegisterType<Autofact>().As<IUnitOfWork>();
            return builder.Build();
        }
    }
}
