using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.DTOs
{
    public class RoundDTO
    {
        public int RoundNumber { get; set; }
        public string PlayerMove { get; set; }
        public string PcMove { get; set; }
        public string Result { get; set; }
    }
}