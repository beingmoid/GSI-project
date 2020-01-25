using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{

        public class PlayerStatsRepository : EFRepository<PlayerStats, int>, IPlayerStatsRepository
    {
            public PlayerStatsRepository(RequestScope<EfContext> requestScope)
                : base(requestScope)
            {

            }
        }
        public interface IPlayerStatsRepository : IEFRepository<PlayerStats, int>
        {

        }
    
}
