using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class Team:BaseEntity<int>
    {
        public string TeamName { get; set; }
        public string TeamImage { get; set; }
        public TeamType TeamType { get; set; }
        public ICollection<TeamPlayers> _teamPlayers;
        public ICollection<TeamPlayers> TeamPlayers => TeamPlayers ?? (_teamPlayers = new List<TeamPlayers>());
        public ICollection<Match> _team1;
        public ICollection<Match> Team1 => Team1 ?? (_team1 = new List<Match>());
        public ICollection<Match> _team2;
        public ICollection<Match> Team2 => Team2 ?? (_team2 = new List<Match>());
    }
    public enum TeamType
    {
        CSGO=1,
        DOTA2=2
    }
}
