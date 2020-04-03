using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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
                item.RoleId = 2;
                item.IsActive = true;
                item.token = Guid.NewGuid();
            }
            return base.WhileInserting(entities);
        }
        protected override void Validation()
        {
            this.Validate(x => x.Email).Mandatory().Duplicate();
        }

        public async Task<object> FilterList(string searchValue)
        {
            var players = (await this.Get(x => x.Id.StartsWith(searchValue))).Values.Select(x => new { x.Id }).ToList().Take(10);
            return players;
        }
    }
    public interface IPlayerService : IBaseService<User,string>
    {
        Task<object> FilterList(string searchValue);
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
