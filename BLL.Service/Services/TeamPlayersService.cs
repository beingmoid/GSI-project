using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   
        public class TeamPlayersService : BaseService<TeamPlayers, int>, ITeamPlayersService
    {
            public TeamPlayersService(RequestScope scopeContext, ITeamPlayerRepository repository)
                : base(scopeContext, repository)
            {

            }
        }
        public interface ITeamPlayersService : IBaseService<TeamPlayers, int>
        {

        }
    
}
