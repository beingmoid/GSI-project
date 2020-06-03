using BLL.Service.Hubs;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service.Services
{
   
        public class PlayerRequestService : BaseService<PlayerRequest, int>, IPlayerRequestService
        {
        private readonly MatchHub _matchub;
            public PlayerRequestService(RequestScope scopeContext,
                MatchHub matchub,
        IPlayerRequestRepository repository)
                : base(scopeContext, repository)
            {
            _matchub = matchub;
            }
        protected override async Task OnInserted(IEnumerable<PlayerRequest> entities)
        {
            var entity = entities?.FirstOrDefault();
            var response = (await this.Get(x => x.Include(o => o.Team)
                                        , x => x.TeamId == entity.TeamId))
                                            .Values
                                                .Select(x => new {
                                                    TeamName = x.Team.TeamName,
                                                    Logo = x.Team.TeamImage
                                                    
                                                }).SingleOrDefault();
                                        
                                        ;
           // await _matchub.TeamJoinRequest(response, entity.PlayerId);
            
        }
    }
        public interface IPlayerRequestService : IBaseService<PlayerRequest, int>
        {

        }
    
}
