using BLL.Service.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace BLL.Service.Hubs
{
    public class MatchHub : Hub
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITeamService _teamService;
        public MatchHub(IHttpContextAccessor httpContextAccessor,
             ITeamService teamService)
        {
            _httpContextAccessor = httpContextAccessor;
            _teamService = teamService;
        }

        public async Task CreateGroup(GameStates states)
        {
            var UserId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;


            var players = (await _teamService.Get(x => x.Include(team => team.TeamPlayers),
                x => x.TeamPlayers.Any(query => query.PlayerId == UserId)))
                .Values
                    .Select(x => new
                    {
                        PlayerIds = x.TeamPlayers.Select(player => player.PlayerId).ToList()

                    })
                        .Select(x => x.PlayerIds)?.FirstOrDefault();
            players.ForEach(async x =>
            {
                await Clients.Client(x).SendAsync("GameStates", states);
            });

        }

        private async Task<List<string>> UserGroupForATeam(int? teamId)
        => (await _teamService.Get(x => x.Include(team => team.TeamPlayers),
               x => x.Id == teamId))
               .Values
                   .Select(x => new
                   {
                       PlayerIds = x.TeamPlayers.Select(player => player.PlayerId).ToList()

                   })
                       .Select(x => x.PlayerIds)?.FirstOrDefault();

        public async Task MatchRequest(object obj, int? SenderTeam, int? ReceiverTeamId)
        {
            var groupOfUser = await UserGroupForATeam(ReceiverTeamId);
            groupOfUser.ForEach(
               async user =>
               await Clients.Client(user).SendAsync("MatchRequest", obj)
                );
        }
        public async Task TeamJoinRequest (object obj, string connectionId)
        {
           await Clients.Client(connectionId).SendAsync("TeamJoinRequests", obj);
        }
        public async Task GameState(GameStates states)
        {
            await Clients.Group("Team").SendAsync("states", states);
        }
        //public  async Task Send(string connectionId,object data,int matchId)
        //{
        //    var State = (await _gameStateService.Get(x => x.MatchId == matchId)).Values.LastOrDefault().GameStateJSON;
        //    var GameState = new GameState(State);
        //    await Clients.Client(connectionId).SendAsync("Send",data);
        //}
    }
}
