using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class UserService : BaseService<User,string>, IUserService
    {
        public UserService(RequestScope scopeContext, IUserRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IUserService : IBaseService<User,string>
    {

    }
}
