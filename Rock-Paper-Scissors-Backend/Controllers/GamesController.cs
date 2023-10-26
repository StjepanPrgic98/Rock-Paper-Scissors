using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Deviate_Portal_Backend.Controllers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors_Backend.DTOs;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IServices;

namespace Rock_Paper_Scissors_Backend.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly IGameService _gameService;
        private readonly IRoundService _roundService;
        public GamesController(IGameService gameService, IRoundService roundService)
        {
            _roundService = roundService;
            _gameService = gameService;
        }

        // To start a new game, make a GET request to: http://localhost:5000/api/games/start
        // This endpoint will return the unique game ID that you'll use in subsequent requests.

        // To play a round, make a GET request to: http://localhost:5000/api/games/{gameId}/{move}
        // Replace "{gameId}" with the game's unique ID, and "{move}" with your chosen move ("rock," "paper," or "scissors").

        // To end the game, make a GET request to: http://localhost:5000/api/games/end/{gameId}


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStatsDTO>>> GetListofGames()
        {
            return Ok(await _gameService.GetListOfGames());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameStatsDTO>> GetGameById(int id)
        {
            if(!_gameService.CheckIfGameExists(id)){return NotFound("Game doesnt exist!");}
            return await _gameService.GetGameById(id);
        }

        [HttpGet("start")]
        public async Task<ActionResult<int>> StartNewGame()
        {
            return await _gameService.StartNewGame();
        }

        [HttpGet("{id}/{playerMove}")]
        public async Task<ActionResult<GameStatsDTO>> PlayRound(int id, string playerMove)
        {     
            if(!_roundService.CheckIfPlayerMoveIsValid(playerMove)){return BadRequest("Invalid move!");}
            Round round = _roundService.CreateRound(playerMove);

            if(!_gameService.CheckIfGameIsActive(id)){return BadRequest("This game is no longer active or doesnt exist!");}
            return await _gameService.PlayRound(id, round);    
        }

        [HttpGet("end/{id}")]
        public async Task<ActionResult<GameStatsDTO>> EndGame(int id)
        {
            if(!_gameService.CheckIfGameIsActive(id)){return BadRequest("This game is no longer active or doesnt exist!");}
            return await _gameService.EndGame(id);
        }
    }
}