using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class MatchRequest : BaseEntity<int>
    {
        public int? SenderTeamId { get; set; }
        public Team  SenderTeam { get; set; }
        public bool IsAccepted { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; } 
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public DateTime MatchTimings { get; set; }
        public MatchType MatchType { get; set; }
        public int? ReceiverTeamId { get; set; }
        public RequestStatus Status { get; set; }
        public Team ReceiverTeam { get; set; }
   

    }
    public enum RequestStatus
    {
        Accepted=1,
        Rejected,
        Pending
    }
    public enum MatchType
    {
        CSGO=1,
        DOTA2
    }
}
