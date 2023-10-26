using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.Interfaces.IServices
{
    public interface IGameService
    {
        Task<int> StartNewGame();
    }
}