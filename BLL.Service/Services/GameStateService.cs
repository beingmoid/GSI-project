using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class GameStateService : BaseService, IGameStateService
    {
        public GameStateService(RequestScope scopeContext)
            :base(scopeContext)
        {

        }
    }
    public interface IGameStateService : IBaseService
    {

    }
}
