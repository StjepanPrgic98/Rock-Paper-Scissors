using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
        public DateTime EndTime { get; set; } = DateTime.MinValue;
        public ICollection<Round> Rounds { get; set; }
    }
}