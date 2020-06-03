using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service.Services
{
   public class TeamService : BaseService<Team,int>, ITeamService
    {

        private ITeamPlayersService _teamPlayerService;
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IMatchRequestService _matchRequestService;
        public TeamService(RequestScope scopeContext, ITeamRepository repository, ITeamPlayersService teamPlayerService,
            IMatchRequestService matchRequestService,
        IHttpContextAccessor httpContextAccessor)

            : base(scopeContext, repository)
        {
            _teamPlayerService = teamPlayerService;
            _httpContextAccessor = httpContextAccessor;

            _matchRequestService = matchRequestService;
        }

        public async Task<object> GetRequestReceived(int teamId)
        {
            var requests= (await _matchRequestService.Get(o=>o.Include(props=>props.SenderTeam),x=>x.ReceiverTeamId==teamId && x.Status==RequestStatus.Pending)).Values.Select(x => new {
                Id=x.Id,
                TeamName = x.SenderTeam.TeamName,
                ContactNumber = x.Contact1,
                Location = x.Contact2
            }).ToList();
            //var requests = (await _matchRequestService.Get(o => o.Include(x => x.ReceiverMatchRequest).ThenInclude(x => x.SenderTeam), x => x.ReceiverMatchRequest.Any(f => f.ReceiverTeamId == teamId))).Values.Select(x=> new { 
            //TeamName=x.ReceiverMatchRequest.Select(i=>i.SenderTeam.TeamName),
            //ContactNumber=x.ReceiverMatchRequest.Select(i=>i.Contact1),
            //Location = x.ReceiverMatchRequest.Select(i=>i.Contact2)
            //}).ToList();
            return requests;
        }

        public Task<object> GetRequestSent(int teamId)
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetTeams(string searchVal, int ownId)
        {
            var teams = (await this.Get(x => x.TeamName.StartsWith(searchVal) && x.Id != ownId)).Values.Select(x => new { x.Id, x.TeamName }).ToList().Take(10);

            return teams;
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
        Task<object> GetTeams(string searchVal,int ownId);
        Task<object> GetRequestSent(int teamId);
        Task<object> GetRequestReceived(int teamId);

    }
}
