using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL.Service;
using BLL.Service.Hubs;
using BLL.Service.Services;
using CSGSI;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
   
    public class GameStateController : BaseController<GameStates,int>
    {
        private readonly IMatchService _matchService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPlayerService _playerService;
        private readonly IMatchDetailsService _matchDetailsService;
        private readonly IPlayerStatsService _playerStatsService;
        private readonly MatchHub _matchHub;
        public GameStateController(RequestScope scopeContext, IGameStateService service,
            IMatchService matchService, IHttpContextAccessor httpContextAccessor,
            IMatchDetailsService matchDetailsService,
            IPlayerService playerService,
            MatchHub matchHub,
            IPlayerStatsService playerStatsService)
            :base(scopeContext,service)
        {
            _matchService = matchService;
            _httpContextAccessor = httpContextAccessor;
            _playerService = playerService;
            _matchDetailsService = matchDetailsService;
            _playerStatsService = playerStatsService;
            _matchHub = matchHub;
        }
       static List<GameState> li = new List<GameState>();


        [AllowAnonymous]
        [HttpPost("State")]
        public async Task<ActionResult> State(int Id, [FromBody] string gameState)
        {

            var GameState = new GameState(gameState);
           // var matchId = Convert.ToInt32(HttpContext.Session.GetString("_matchId")!="" || HttpContext.Session.GetString("_matchId") != null? HttpContext.Session.GetString("_matchId"):"0" );

            //if (matchId>0)
            //{

            
            await  this.Service.Insert(new[] { new GameStates() {
             MatchId=Id ,
              GameStateJSON=gameState
          } });
         
            return Ok();
            
        }
        
        [HttpGet("GetState")]
        public async void  GetState(int matchId)
        {
            var State = (await this.Service.Get(x => x.MatchId == matchId)).Values.LastOrDefault().GameStateJSON;
            var GameState = new GameState(State);
            //var hub = GlobalHost.ConnectionManager.GetHubContext<Connection>();
            var userId = this.User.FindFirst(x => x.Type == "UserId")?.Value;
            //await _matchHub.Send(userId, GameState);
            
        }
    }
}
