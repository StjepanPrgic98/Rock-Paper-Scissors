using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IRepositories;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;

namespace Rock_Paper_Scissors_Backend.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository; 
        }

        public async Task<IEnumerable<Game>> GetListOfGames()
        {
            return await _gameRepository.GetListOfGames();
        }

        public async Task<int> StartNewGame()
        {
            Game game = new Game
            {
                GameNumber = GenerateGameNumber(),
                Active = true
            };

            return await _gameRepository.StartNewGame(game);
        }


        // Generates a number between 100000 and 999999 that will be used as game unique number.
        private int GenerateGameNumber()
        {
            Random random = new Random();
            return random.Next(100000, 1000000);
        }
    }
}