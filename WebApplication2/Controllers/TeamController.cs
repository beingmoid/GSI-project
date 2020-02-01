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
        public TeamController(RequestScope scopeContext,ITeamService service)
            :base(scopeContext,service)
        {

            _teamService = service;
        }
        //public override Task<ActionResult> Post([FromBody] Team entity)
        //{
        //    //entity.PlayerId = this.User.Claims.First(i => i.Type == "UserId").Value;
        //    //entity.IsCaptain = true;
        //    return base.Post(entity);
        //}
        //[HttpGet("GetTeams")]
        //public async Task<ActionResult> GetTeams() {
            
        //    var playerId = this.User.Claims.First(i => i.Type == "UserId")?.Value;
        //    return new JsonResult((await _teamService.GetTeams(playerId)));

        //} 
    }
}
