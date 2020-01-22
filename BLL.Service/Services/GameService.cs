using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   public class GameService : BaseService<Game,int>, IGameService
    {
        public GameService(RequestScope scopeContext, IGameRepository repository)
            :base(scopeContext, repository)
        {

        }
    }
    public interface IGameService : IBaseService<Game,int>
    {

    }
}
