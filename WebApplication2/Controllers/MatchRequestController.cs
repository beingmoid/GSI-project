using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Service.Hubs;
using BLL.Service.Services;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
   
    public class MatchRequestController : BaseController<MatchRequest,int>
    {
        private IHubContext<MatchHub> _matchHub;
        public MatchRequestController(RequestScope scopeContext,IMatchRequestService service
            , IHubContext<MatchHub> matchHub)
            :base(scopeContext,service)
        {
            _matchHub = matchHub;
        }
        public async override Task<ActionResult> Post([FromBody] MatchRequest entity)
        {
            entity.Status = RequestStatus.Pending;
            var JsonResult=  await base.Post(entity);
            var obj = (await this.Service.Get(x => x.Include(o => o.SenderTeam).
                                                 Include(o => o.ReceiverTeam)
                                                    , x => x.SenderTeamId == entity.SenderTeamId && x.ReceiverTeamId == entity.ReceiverTeamId
                                                     && x.Status == RequestStatus.Pending
                        ))
                .Values
                    .Select(x => new {
                        SenderTeamName = x.SenderTeam.TeamName,
                        SenderTeamLogo = x.SenderTeam.TeamImage,
                        SenderTeamContact = x.Contact1,
                    });
            await _matchHub.Clients.All.SendCoreAsync("Send", new[] { obj});
           // await _matchHub.MatchRequest(obj, entity.SenderTeamId, entity.ReceiverTeamId);
            return  JsonResult;

        }
        [HttpGet("IsAccepted")]
        public async Task<ActionResult> AcceptReject(int Id,bool value)
        {
            var request = await this.Service.GetOne(x => x.Id == Id);
            request.IsAccepted = value;
            request.Status = value? RequestStatus.Accepted : RequestStatus.Rejected;
            return new JsonResult(await this.Service.Update(Id, request));
        }

        [HttpGet("AcceptedRequest")]
        public async Task<ActionResult> AcceptedRequest(int? teamId)
        {
            var req =  (await this.Service.Get(o=>  o.Include(f=>f.SenderTeam).Include(f=>f.ReceiverTeam),x => ((x.SenderTeamId == teamId) || (x.ReceiverTeamId == teamId)) && (x.IsAccepted == true) && (x.Status==RequestStatus.Accepted))).Values.Select(
                x=> new
                {
                    Id=x.Id,
                    SenderId=x.SenderTeamId,
                    ReceiverId = x.ReceiverTeamId,
                    SenderName= x.SenderTeam.TeamName,
                    ReceiverName= x.ReceiverTeam.TeamName
                }
                ).ToList();

            return new JsonResult(req);
        }
    }
}
