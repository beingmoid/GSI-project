using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service.Services
{
   
        public class TeamPlayersService : BaseService<TeamPlayers, int>, ITeamPlayersService
    {
            public TeamPlayersService(RequestScope scopeContext, ITeamPlayerRepository repository)
                : base(scopeContext, repository)
            {

            }


        public async Task<object> GetTeams(string PlayerId)
        {
            var teams = (await this.Get(x=>x.Include(o=>o.Team).Include(o=>o.Player),x => x.PlayerId == PlayerId))?.Values.Distinct().Select(x=> new { 
            Id=x.TeamId,
            TeamName=x.Team.TeamName,
            ImageUrl = x.Team.TeamImage
            }).ToList();
            return teams;
        }

    }
    public interface ITeamPlayersService : IBaseService<TeamPlayers, int>
        {
        Task<object> GetTeams(string PlayerId);
    }

}
