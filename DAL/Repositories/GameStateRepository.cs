using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class GameStateRepository : EFRepository<GameStates,int>, IGameStateRepository
    {
        public GameStateRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IGameStateRepository : IEFRepository<GameStates,int>
    {

    }
}
