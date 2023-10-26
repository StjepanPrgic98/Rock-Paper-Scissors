using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Data;

namespace Rock_Paper_Scissors_Backend.Interfaces.IRepositories
{
    public interface IGameRepository
    {
        Task<int> StartNewGame();
    }
}