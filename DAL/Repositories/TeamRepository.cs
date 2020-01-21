using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class TeamRepository : EFRepository<Team,int>, ITeamRepository
    {
        public TeamRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface ITeamRepository : IEFRepository<Team,int>
    {

    }
}
