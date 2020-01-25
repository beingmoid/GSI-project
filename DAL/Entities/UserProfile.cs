using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserProfile:BaseEntity<int>
    {
        public string UserId { get; set; }
        public int? TeamId { get; set; }
        public int PlayerStatsId { get; set; }
        public User User { get; set; }
        public Team Team { get; set; }
        public PlayerStats PlayerStats { get; set; }

    }
}
