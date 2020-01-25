using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class PlayerStats:BaseEntity<int>
    {
        public string PlayerId { get; set; }
        public int MatchId { get; set; }
        public int Kills { get; set; }
        public int Deths { get; set; }

        public User Player { get; set; }
        public Match Match { get; set; }

        private ICollection<UserProfile> _userProfile;
        public ICollection<UserProfile> UserProfile => _userProfile ?? (_userProfile = new List<UserProfile>());

    }
}
