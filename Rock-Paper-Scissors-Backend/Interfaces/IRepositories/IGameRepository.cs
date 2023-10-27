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
        Task<Game> StartNewGame(Game game);
        Task<Game> SaveGame(Game game);
        Task<Game> GetGameById(int id);

        bool CheckIfGameExists(int id);
        bool CheckIfGameIsActive(int id);
    }
}