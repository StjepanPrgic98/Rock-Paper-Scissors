using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Interfaces.IServices
{
    public interface IRoundService
    {
        Round CreateRound(string playerMove);
        bool CheckIfPlayerMoveIsValid(string playerMove);
    }
}