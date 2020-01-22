using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class RoleRightService : BaseService<RoleRight,int>, IRoleRightService
    {
        public RoleRightService(RequestScope scopeContext, IRoleRightRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IRoleRightService : IBaseService<RoleRight,int>
    {

    }
}
