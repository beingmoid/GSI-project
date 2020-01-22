using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeamPlayerRepository : EFRepository<TeamPlayers,int>, ITeamPlayerRepository
    {
        public TeamPlayerRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface ITeamPlayerRepository : IEFRepository<TeamPlayers,int>
    {

    }
}
