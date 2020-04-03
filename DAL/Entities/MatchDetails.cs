using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
   public class MatchDetails : BaseEntity<int>
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }
        public string Score { get; set; }
        public bool IsActive  { get; set; }
        public bool Status { get; set; }
        public int? WinningTeamId { get; set; }
        public Team WinningTeam { get; set; }


    }
}
