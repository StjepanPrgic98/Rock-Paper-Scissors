using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Data;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Interfaces.IRepositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetListOfGames();
        Task<int> StartNewGame(Game game);
        Task<Game> SaveGame(Game game);
        Task<Game> GetGameByNumber(int gameNumber);
    }
}