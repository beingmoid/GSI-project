using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class MatchRepository : EFRepository<Match,int>, IMatchRepository
    {
        public MatchRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IMatchRepository : IEFRepository<Match,int>
    {

    }
}
