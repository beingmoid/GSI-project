using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class MatchRequestRepository : EFRepository<MatchRequest,int>, IMatchRequestRepository
    {
        public MatchRequestRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IMatchRequestRepository : IEFRepository<MatchRequest, int>
    {

    }
}
