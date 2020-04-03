using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class GameStateService : BaseService<GameStates,int>, IGameStateService
    {
        public GameStateService(RequestScope scopeContext, IGameStateRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IGameStateService : IBaseService<GameStates, int>
    {

    }
}
