using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Interfaces.IServices
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetListOfGames();
        Task<int> StartNewGame();
    }
}