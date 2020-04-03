using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
   
    public class MatchController : BaseController<Match,int>
    {
        IMatchService _service;
        private readonly ITeamPlayersService _teamPlayerService;
        private readonly IMatchRequestService _matchRequestService;
        public MatchController(RequestScope scopeContext,IMatchService service, IMatchRequestService matchRequestService
            , ITeamPlayersService teamPlayerService )
            :base(scopeContext,service)
        {
            _service = service;
            _teamPlayerService = teamPlayerService;
            _matchRequestService = matchRequestService;
        }

        [HttpPost("BeginMatch")]
        public async Task<ActionResult> BeginMatch([FromBody] BeginMatch request)
        {
        
            await _matchRequestService.Delete(request.MatchRequestId);

            if (request.TeamId == request.TeamId2)
            {
                throw new ServiceException(System.Net.HttpStatusCode.OK, "Both team cannot be same");
            }
            Match m = new Match(); 
            m.Team1Id = request.TeamId;
            m.Team2Id = request.TeamId2;
            m.IsActive = true;
            m.IsFinished = false;
            m.Status = MatchStatus.Started;

            var match = (await _service.Insert(new[] { m }));
            HttpContext.Session.SetString("_matchId", match.Entities.Values.ToList()[0].Id.ToString());

            return new JsonResult(match);
        }
        [HttpGet("CurrentMatch")]
        public async Task<ActionResult> CurrentMatch(int ? teamId)
        {
            int TeamId;
            if (teamId==null)
            {
                var user = this.User.FindFirst(x => x.Type == "UserId")?.Value;
                TeamId = Convert.ToInt32((await _teamPlayerService.Get(x => x.PlayerId == user)).Values?.Select(x => x.Id));
                return new JsonResult(TeamId>0?await _service.CurrentMatch(TeamId):"No Match Found");
            }
            return new JsonResult(await _service.CurrentMatch(Convert.ToInt32(teamId)));
        }
    }
}
public class BeginMatch
{
    public int TeamId { get; set; }
    public int TeamId2 { get; set; }
    public int MatchRequestId { get; set; }
}