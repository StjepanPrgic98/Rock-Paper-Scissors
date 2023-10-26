using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deviate_Portal_Backend.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;

namespace Rock_Paper_Scissors_Backend.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly IGameService _gameService;
        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetListofGames()
        {
            try
            {
                return Ok(await _gameService.GetListOfGames());
            }
            catch(Exception ex)
            {
                return BadRequest($"Failed to get list of games! \n {ex}");
            }
        }

        [HttpGet("start")]
        public async Task<ActionResult<int>> StartNewGame()
        {
            return await _gameService.StartNewGame();
        }
    }
}