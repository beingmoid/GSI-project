using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
   
    public class TeamController : BaseController<Team,int>
    {
        private readonly ITeamService _teamService;
        private ITeamPlayersService _teamPlayerService;
        public TeamController(RequestScope scopeContext,ITeamService service,
            ITeamPlayersService teamPlayerService)
            :base(scopeContext,service)
        {
            _teamPlayerService = teamPlayerService;
            _teamService = service;
        }
        [HttpGet("GetRequestReceived")]
        public async Task<ActionResult> TeamRequest(int teamId) => new JsonResult(await _teamService.GetRequestReceived(teamId));

        [HttpGet("TeamSearch")]
        public async Task<ActionResult> TeamSearch(string searchVal, int ownId) => new JsonResult(await _teamService.GetTeams(searchVal, ownId));
        
    }
}
