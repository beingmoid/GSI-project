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
        //public bool IsCaptain { get; set; }
        //public string PlayerId { get; set; }
        //public User Player { get; set; }
        private ICollection<TeamPlayers> _teamPlayers;
        public ICollection<TeamPlayers> TeamPlayers => _teamPlayers ?? (_teamPlayers = new List<TeamPlayers>());
        private ICollection<Match> _team1;
        public ICollection<Match> Team1 => _team1 ?? (_team1 = new List<Match>());
        private ICollection<Match> _team2;
        public ICollection<Match> Team2 => _team2 ?? (_team2 = new List<Match>());

        private ICollection<MatchDetails> _WinningTeam;
        public ICollection<MatchDetails> WinningTeam => _WinningTeam ?? (_WinningTeam = new List<MatchDetails>());


        private ICollection<PlayerRequest> _playerRequest;
        public ICollection<PlayerRequest> PlayerRequest => _playerRequest ?? (_playerRequest = new List<PlayerRequest>());
    
        private ICollection<UserProfile> _userProfile;
        public ICollection<UserProfile> UserProfile => _userProfile ?? (_userProfile = new List<UserProfile>());


        private ICollection<MatchRequest> _SenderMatchRequest;
        public ICollection<MatchRequest> SenderMatchRequest => _SenderMatchRequest ?? (_SenderMatchRequest = new List<MatchRequest>());

        private ICollection<MatchRequest> _ReceiverMatchRequest;
        public ICollection<MatchRequest> ReceiverMatchRequest => _ReceiverMatchRequest ?? (_ReceiverMatchRequest = new List<MatchRequest>());


    }
    public enum TeamType
    {
        CSGO=1,
        DOTA2=2
    }
}
