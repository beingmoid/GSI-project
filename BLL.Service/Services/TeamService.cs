using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class TeamService : BaseService<Team,int>, ITeamService
    {
        public TeamService(RequestScope scopeContext, ITeamRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface ITeamService : IBaseService<Team,int>
    {

    }
}
