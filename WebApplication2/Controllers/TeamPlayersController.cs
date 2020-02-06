using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
    public class TeamPlayersController : BaseController<TeamPlayers,int>
    {
        private ITeamPlayersService _teamPlayerService;
        public TeamPlayersController(RequestScope scopeContext,ITeamPlayersService service)
            :base(scopeContext,service)
        {
            _teamPlayerService = service;
        }
        [HttpGet("GetTeams")]
        public async Task<ActionResult> GetTeams()
        {
            var playerId = this.User.Claims.First(i => i.Type == "UserId")?.Value;
            return new JsonResult((await _teamPlayerService.GetTeams(playerId)));
        } 

    }
}
