using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL;

namespace BLL.Service.Services
{
   
        public class TeamPlayersService : BaseService<TeamPlayers, int>, ITeamPlayersService
    {
        RequestScope _scopeContext;
            public TeamPlayersService(RequestScope scopeContext, ITeamPlayerRepository repository)
                : base(scopeContext, repository)
            {
            _scopeContext = scopeContext;
            }
        protected override void Validation()
        {
            this.Validate(x => x.PlayerId,"Already a part of team").Duplicate();
            base.Validation();
        }

        public async Task<object> GetTeams(string PlayerId)
        {

           
            // var teams = (await this.Get(/*x => x.Include(o => o.Team),*/ x => x.PlayerId == PlayerId));
            var teams = (await this.Get(o => o.Include(z => z.Team), x => x.PlayerId == PlayerId))?.Values.Select(x => new
            {
                Id = x.TeamId,
                TeamName = x.Team.TeamName,
                ImageUrl = x.Team.TeamImage
            }).ToList();
            return teams;
        }

       
    }
    public interface ITeamPlayersService : IBaseService<TeamPlayers, int>
        {
        Task<object> GetTeams(string PlayerId);
        //Task<object> SaveCaptain(string playerId, int TeamId);
    }

}
