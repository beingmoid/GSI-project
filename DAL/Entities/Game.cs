using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class Game : BaseEntity<int>
	{
		public string PlayerId { get; set; }
		public GameType GameType { get; set; }
		public User Player { get; set; }

	}
	public enum GameType
	{
		CSGO=1,
		DOTA2=2
	}
}
