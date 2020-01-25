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
		private ICollection<Game> _game;
		public ICollection<Game> Games
		{
			get => _game ?? (_game = new List<Game>());

		}
		//public ICollection<GenUnLocation> GenPortsOfACountry
		//{
		//	get => _genPortsOfACountry ?? (_genPortsOfACountry = new List<GenUnLocation>());
		//}
		private ICollection<TeamPlayers> _teamPlayers;
		public ICollection<TeamPlayers> TeamPlayers => _teamPlayers ?? (_teamPlayers = new List<TeamPlayers>());

	}
}
