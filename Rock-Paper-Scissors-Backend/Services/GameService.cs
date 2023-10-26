using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public Task<int> StartNewGame()
        {
            throw new NotImplementedException();
        }
    }
}