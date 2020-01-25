using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service.Services
{
   public class PlayerService : BaseService<User,string>, IPlayerService
    {
        public PlayerService(RequestScope scopeContext, IPlayerRepository repository)
            :base(scopeContext, repository)
        {

        }
        protected override Task WhileInserting(IEnumerable<User> entities)
        {
            foreach (var item in entities)
            {
                item.RoleId = 1;
            }
            return base.WhileInserting(entities);
        }
    }
    public interface IPlayerService : IBaseService<User,string>
    {

    }
    public class Player
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string SteamId { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}
