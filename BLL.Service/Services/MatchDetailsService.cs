using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   
        public class MatchDetailsService : BaseService<MatchDetails, int>, IMatchDetailsService
    {
            public MatchDetailsService(RequestScope scopeContext, IMatchDetailsRepository repository)
                : base(scopeContext, repository)
            {

            }
        }
        public interface IMatchDetailsService : IBaseService<MatchDetails, int>
        {

        }
    
}
