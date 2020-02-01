using DAL.Entities;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Services
{
   public class TeamService : BaseService<Team,int>, ITeamService
    {
   
        public TeamService(RequestScope scopeContext, ITeamRepository repository)

            : base(scopeContext, repository)
        {
          
        }

        //public async Task<List<Team>> GetTeams(string PlayerId)
        //{
        //    //var teams = (await this.Get(x => x.PlayerId == PlayerId))?.Values.ToList();
        //   // return teams;
        //}
    
    
    }
    public interface ITeamService : IBaseService<Team, int>
    {
       // Task<List<Team>> GetTeams(string PlayerId);
    }
}
