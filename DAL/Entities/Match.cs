using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class Match:BaseEntity<int>
    {
        public int? Team1Id { get; set; }
        public Team Team1 { get; set; }
        public bool IsActive { get; set; }
        public decimal? Latitude { get; set; }
        public decimal Longitude { get; set; } 
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public int? Team2Id { get; set; }
        public Team Team2 { get; set; }
        public bool? IsStart { get; set; }
        public bool? IsFinished { get; set; }
        public int? ApprovalCounter { get; set; }
        public MatchStatus Status { get; set; }



        private ICollection<MatchDetails> matchDetails;
        public ICollection<MatchDetails> MatchDetails => matchDetails ?? (matchDetails = new List<MatchDetails>());

        private ICollection<PlayerStats> _playerStats;
        public ICollection<PlayerStats> PlayerStats => _playerStats ?? (_playerStats = new List<PlayerStats>());
        private ICollection<GameStates> _matchStates;
        public ICollection<GameStates> GameStates => _matchStates ?? (_matchStates = new List<GameStates>());

    }
    public enum MatchStatus:int
    {
        Started=1,
        OnGoing,
        Paused,
        Cancelled,
        FatalError,
        Finished
    }
}
