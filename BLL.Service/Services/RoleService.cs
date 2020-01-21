using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class RoleService:BaseService<Role,int>,IRoleService
    {
        public RoleService(RequestScope scopeContext, IRoleRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IRoleService:IBaseService<Role,int>
    {

    }
}
