using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;

namespace Rock_Paper_Scissors_Backend.Controllers
{
    public class GamesController
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }
    }
}