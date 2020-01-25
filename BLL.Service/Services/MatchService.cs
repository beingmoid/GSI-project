using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Services
{
   public class MatchService : BaseService<Match,int>, IMatchService
    {
        public MatchService(RequestScope scopeContext, IMatchRepository repository)
            :base(scopeContext, repository)
        {

        }

        protected override Task WhileInserting(IEnumerable<Match> entities)
        {
            foreach (var item in entities)
            {
                item.IsActive = true;
            }
            return base.WhileInserting(entities);
        }
    }
   
    public interface IMatchService : IBaseService<Match,int>
    {

    }
}
