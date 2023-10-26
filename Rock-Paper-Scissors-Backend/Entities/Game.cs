using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int GameNumber { get; set; }
        public bool Active { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }
}