using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service.Hubs;
using BLL.Service.Services;
using CSGSI;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace WebApplication2.Controllers
{

    public class GameDataController : BaseController
    {
        private readonly IHubContext<MatchHub> matchHub;
        private readonly MatchHub _matchHub;
        public GameDataController(RequestScope scopeContext, IGameService service , IHubContext<MatchHub> matchHub , MatchHub _matchHub)
            : base(scopeContext, service)
        {
            this.matchHub = matchHub;
            this._matchHub = _matchHub;
        }
        [AllowAnonymous]
        [HttpPost("RequestPayload")]
        public async Task<IActionResult> RequestPayload(object obj)

        {
            var json = obj.ToString();
            //var states = new  GameState(json);
            var convert = JsonConvert.DeserializeObject(json).ToString();
            try
            {
                if (MatchHub.users.Count==0)
                {
                    return Ok();
                }
                await matchHub.Clients.All.SendAsync("SendToEveryone", "aa",convert);
            
            }
            catch (Exception)
            {

              
            }

            convert = null;
            return Ok();
        }
    }
}
