using BLL.Service.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace BLL.Service.Hubs
{

    [EnableCors("AllowAll")]
    [AllowAnonymous]
    
    public class MatchHub : Hub<IMatchHub>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITeamService _teamService;
        public MatchHub(IHttpContextAccessor httpContextAccessor,
             ITeamService teamService)
        {
            _httpContextAccessor = httpContextAccessor;
            _teamService = teamService;
        }

        //public async Task CreateGroup(GameStates states)
        //{
        //    var UserId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;


        //    var players = (await _teamService.Get(x => x.Include(team => team.TeamPlayers),
        //        x => x.TeamPlayers.Any(query => query.PlayerId == UserId)))
        //        .Values
        //            .Select(x => new
        //            {
        //                PlayerIds = x.TeamPlayers.Select(player => player.PlayerId).ToList()

        //            })
        //                .Select(x => x.PlayerIds)?.FirstOrDefault();
        //    players.ForEach(async x =>
        //    {
        //        await Clients.Client(x).SendAsync("GameStates", states);
        //    });

        //}

        private async Task<List<string>> UserGroupForATeam(int? teamId)
        => (await _teamService.Get(x => x.Include(team => team.TeamPlayers),
               x => x.Id == teamId))
               .Values
                   .Select(x => new
                   {
                       PlayerIds = x.TeamPlayers.Select(player => player.PlayerId).ToList()

                   })
                       .Select(x => x.PlayerIds)?.FirstOrDefault();
        [HubMethodName("SendMessage")]
        public  Task SendToAll(object ob)
        {
             return Clients.All.SendToAll(ob);
        }
        public async Task<string> GetTotalLength(string param1)
        {
            return param1.Length.ToString();
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
        public Task ThrowException()
        {
            throw new HubException("This error will be sent to the client!");
        }
        //public async Task MatchRequest(object obj, int? SenderTeam, int? ReceiverTeamId)
        //{
        //    var groupOfUser = await UserGroupForATeam(ReceiverTeamId);
        //    foreach (var item in groupOfUser)
        //    {
        //        await Clients.Client(item).SendAsync("MatchRequest", obj);
        //    }


        //}
        //public async Task TeamJoinRequest (object obj, string connectionId)
        //{
        //   await Clients.Client(connectionId).SendAsync("TeamJoinRequests", obj);
        //}

        //public async Task GameState(GameStates states)
        //{
        //    await Clients.Group("Team").SendAsync("states", states);
        //}
        //public  async Task Send(string connectionId,object data,int matchId)
        //{
        //    var State = (await _gameStateService.Get(x => x.MatchId == matchId)).Values.LastOrDefault().GameStateJSON;
        //    var GameState = new GameState(State);
        //    await Clients.Client(connectionId).SendAsync("Send",data);
        //}
    }
    public interface IMatchHub
    {
        Task SendToAll(object ob);
    }
}
