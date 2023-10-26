using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.DTOs
{
    public class GameStatsDTO
    {
        public int GameNumber { get; set; }
        public bool Active { get; set; }
        public int NumberOfRounds { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public List<RoundDTO> Rounds { get; set; }
    }
}