using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRepository:EFRepository<Role,int>,IRoleRepository
    {
        public RoleRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IRoleRepository:IEFRepository<Role,int>
    {

    }
}
