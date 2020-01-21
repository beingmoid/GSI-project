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

    }
}
