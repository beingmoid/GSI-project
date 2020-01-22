using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class UserRepository : EFRepository<User,string>, IUserRepository
    {
        public UserRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IUserRepository : IEFRepository<User,string>
    {

    }
}
