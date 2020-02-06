using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Services
{
   public class TeamService : BaseService<Team,int>, ITeamService
    {

        private ITeamPlayersService _teamPlayerService;
        private IHttpContextAccessor _httpContextAccessor;
        public TeamService(RequestScope scopeContext, ITeamRepository repository, ITeamPlayersService teamPlayerService,
            IHttpContextAccessor httpContextAccessor)

            : base(scopeContext, repository)
        {
            _teamPlayerService = teamPlayerService;
            _httpContextAccessor = httpContextAccessor;
        }

        //public async Task<List<Team>> GetTeams(string PlayerId)
        //{
        //    //var teams = (await this.Get(x => x.PlayerId == PlayerId))?.Values.ToList();
        //   // return teams;
        //}
        protected async override Task OnInserted(IEnumerable<Team> entities)
        {
            foreach (var entity in entities)
            {
                List<TeamPlayers> li = new List<TeamPlayers>();
                var UserId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;
                li.Add(new TeamPlayers { PlayerId = UserId, TeamId = entity.Id, IsCaptain = true });
                await _teamPlayerService.Insert(li);
            }
        
        
        }

    }
    public interface ITeamService : IBaseService<Team, int>
    {
       // Task<List<Team>> GetTeams(string PlayerId);
    }
}
