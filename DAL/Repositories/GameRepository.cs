using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class GameRepository : EFRepository<Game,int>, IGameRepository
    {
        public GameRepository(RequestScope<EfContext>requestScope)
            :base(requestScope)
        {

        }
    }
    public interface IGameRepository : IEFRepository<Game,int>
    {

    }
}
