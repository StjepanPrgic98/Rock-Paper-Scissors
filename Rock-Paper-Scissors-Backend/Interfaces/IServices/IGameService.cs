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
        Task<int> StartNewGame();
        Task<GameStatsDTO> PlayRound(int gameNumber, Round round);
        Task<GameStatsDTO> EndGame(int gameNumber);
        Task<GameStatsDTO> GetGameByNumber(int gameNumber);
    }
}