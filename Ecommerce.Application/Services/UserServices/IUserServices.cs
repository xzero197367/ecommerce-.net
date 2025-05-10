using Ecommerce.Application.Mapping;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices
    {
       

        public void Register(UserRegisterDTO dto);
        public void Login(UserLoginDTO dto);

        public List<User> AdminViewsAllClientUsers();

        public bool AdminActivatesClientUserAccount(int userId);

        public bool AdminDeactivatesClientUserAccount(int userId);

        public bool AdminAddsAdminUser(CreateAdminUserDto dto);

        public List<AdminUserDto> AdminViewsAllAdminUsers();

        //public bool AdminActivatesAdminUserAccount(int userId);

        //public bool AdminDeactivatesAdminUserAccount(int userId);

        public bool AdminManagesOtherAmins(int adminTargetId, int AdminActorId, bool activate);

    }
}
