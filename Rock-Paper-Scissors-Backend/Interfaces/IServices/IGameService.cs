using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.DTOs;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Interfaces.IServices
{
    public interface IGameService
    {
        Task<IEnumerable<GameStatsDTO>> GetListOfGames();
        Task<GameStatsDTO> StartNewGame();
        Task<GameStatsDTO> PlayRound(int id, Round round);
        Task<GameStatsDTO> EndGame(int id);
        Task<GameStatsDTO> GetGameById(int id);
        bool CheckIfGameExists(int id);
        bool CheckIfGameIsActive(int id);
    }
}