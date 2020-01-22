using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class MatchService : BaseService<Match,int>, IMatchService
    {
        public MatchService(RequestScope scopeContext, IMatchRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IMatchService : IBaseService<Match,int>
    {

    }
}
