using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace DAL.Entities
{
    public class User:BaseEntity<string>
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public override string Id { get => base.Id; set => base.Id = value; }
		[JsonIgnore]
		public string Password { get; set; }
		public string SteamId { get; set; }
		public string Email { get; set; }
		public int RoleId { get; set; }
		public Role Role { get; set; }
		public bool IsActive { get; set; }
		public ICollection<Game> _game;
		public ICollection<Game> Games => Games ?? (_game = new List<Game>());

		public ICollection<TeamPlayers> _teamPlayers;
		public ICollection<TeamPlayers> TeamPlayers => TeamPlayers ?? (_teamPlayers = new List<TeamPlayers>());

	}
}
