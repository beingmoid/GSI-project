using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   
        public class PlayerStatsService : BaseService<PlayerStats, int>, IPlayerStatsService
    {
            public PlayerStatsService(RequestScope scopeContext, IPlayerStatsRepository repository)
                : base(scopeContext, repository)
            {

            }
        }
        public interface IPlayerStatsService : IBaseService<PlayerStats, int>
        {

        }
    
}
