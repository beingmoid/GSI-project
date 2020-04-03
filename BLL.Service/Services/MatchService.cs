using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BLL.Service.Services
{
   public class MatchService : BaseService<Match,int>, IMatchService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MatchService(RequestScope scopeContext, IMatchRepository repository,
            IHttpContextAccessor httpContextAccessor
            )
            :base(scopeContext, repository)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<object> CurrentMatch(int teamId)
        {
            var User = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == "UserId")?.Value;
            var CurrentMatch = (await this.Get(x => x.Include(t => t.Team1).
            Include(t2 => t2.Team2).
            Include(game=>game.GameStates),
            //predicate logic
            predicate => 
            ((predicate.Team1.Id == teamId) || (predicate.Team2.Id == teamId)) &&
            ((predicate.Status == MatchStatus.OnGoing) || (predicate.Status == MatchStatus.Started)))).Values.Select(selector=> new { 
            
                MatchId=selector.Id,
                Challenger =selector.Team1.TeamName,
                GameState= selector.GameStates.Any(x=>x.MatchId==selector.Id)? selector.GameStates.Select(x=>x.GameStateJSON):null,
                Team2= selector.Team2.TeamName
            });
            return CurrentMatch;

        }

        protected override Task WhileInserting(IEnumerable<Match> entities)
        {
            foreach (var item in entities)
            {
                item.IsActive = true;
            }
            return base.WhileInserting(entities);
        }
    }
   
    public interface IMatchService : IBaseService<Match,int>
    {
        Task<object> CurrentMatch(int teamId);
    }
}
