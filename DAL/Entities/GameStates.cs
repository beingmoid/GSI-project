using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
	public class GameStates : BaseEntity<int>
	{
		public int MatchId { get; set; }
		public Match Match { get; set; }
		public string GameStateJSON { get; set; }


	}

}
