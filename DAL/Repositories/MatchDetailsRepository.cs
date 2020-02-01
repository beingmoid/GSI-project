using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{

        public class MatchDetailsRepository : EFRepository<MatchDetails, int>, IMatchDetailsRepository
    {
            public MatchDetailsRepository(RequestScope<EfContext> requestScope)
                : base(requestScope)
            {

            }
        }
        public interface IMatchDetailsRepository : IEFRepository<MatchDetails, int>
        {

        }
    
}
