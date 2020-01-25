using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{

        public class PlayerRequestRepository : EFRepository<PlayerRequest, int>, IPlayerRequestRepository
        {
            public PlayerRequestRepository(RequestScope<EfContext> requestScope)
                : base(requestScope)
            {

            }
        }
        public interface IPlayerRequestRepository : IEFRepository<PlayerRequest, int>
        {

        }
    
}
