using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRightRepository : EFRepository<RoleRight,int>, IRoleRightRepository
    {
        public RoleRightRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IRoleRightRepository : IEFRepository<RoleRight,int>
    {

    }
}
