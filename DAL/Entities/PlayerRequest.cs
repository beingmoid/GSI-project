using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class PlayerRequest:BaseEntity<int>

    {
        
        public int TeamId { get; set; }
        public string PlayerId { get; set; }
        public User Player { get; set; }
        public Team Team { get; set; }




    }
}
