using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   
        public class PlayerRequestService : BaseService<PlayerRequest, int>, IPlayerRequestService
        {
            public PlayerRequestService(RequestScope scopeContext, IPlayerRequestRepository repository)
                : base(scopeContext, repository)
            {

            }
        }
        public interface IPlayerRequestService : IBaseService<PlayerRequest, int>
        {

        }
    
}
