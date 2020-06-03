using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using BLL.Service.Hubs;
using System.Net;

namespace BLL.Service.Services
{
   public class MatchRequestService : BaseService<MatchRequest,int>, IMatchRequestService
    {
       // private readonly MatchHub _hubContext;

        public MatchRequestService(RequestScope scopeContext, IMatchRequestRepository repository
            
           /*, MatchHub hubContext*/)
            :base(scopeContext, repository)
        {
            //_hubContext = hubContext;
           
        }
        protected async override Task WhileInserting(IEnumerable<MatchRequest> entities)
        {
            var team = (await this.Get(x => x.SenderTeamId == entities.FirstOrDefault().SenderTeamId && x.ReceiverTeamId == entities.FirstOrDefault().ReceiverTeamId

                    && x.Status == RequestStatus.Pending)).Values.ToList();

            if (team.Count>1)
            {
                throw new ServiceException(HttpStatusCode.OK, "You Cannot Send A team more than one request");
            }
           
           // return base.WhileInserting(entities);
        }
        protected async override Task OnInserted(IEnumerable<MatchRequest> entities)
        {
            var entity = entities.ToList().FirstOrDefault();
            var obj = (await this.Get(x => x.Include(o => o.SenderTeam).
                                                 Include(o => o.ReceiverTeam)
                                                    , x => x.SenderTeamId == entity.SenderTeamId && x.ReceiverTeamId == entity.ReceiverTeamId
                                                     && x.Status == RequestStatus.Pending
                        ))
                .Values
                    .Select(x => new {
                        SenderTeamName = x.SenderTeam.TeamName,
                        SenderTeamLogo  = x.SenderTeam.TeamImage,
                        SenderTeamContact = x.Contact1,
                    });
           //await _hubContext.MatchRequest(obj, entity.SenderTeamId, entity.ReceiverTeamId);
        }

    }
   
    public interface IMatchRequestService : IBaseService<MatchRequest,int>
    {
        
    }
}
