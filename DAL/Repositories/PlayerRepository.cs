using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class PlayerRepository : EFRepository<User,string>, IPlayerRepository
    {
        public PlayerRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IPlayerRepository : IEFRepository<User,string>
    {

    }
}
