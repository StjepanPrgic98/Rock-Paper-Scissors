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

        [HttpGet("{gameNumber}")]
        public async Task<ActionResult<GameStatsDTO>> GetGameByNumber(int gameNumber)
        {
            return await _gameService.GetGameByNumber(gameNumber);
        }

        [HttpGet("start")]
        public async Task<ActionResult<int>> StartNewGame()
        {
            return await _gameService.StartNewGame();
        }

        [HttpGet("{gameNumber}/{playerMove}")]
        public async Task<ActionResult<GameStatsDTO>> PlayRound(int gameNumber, string playerMove)
        {     
            if(!_roundService.CheckIfPlayerMoveIsValid(playerMove)){return BadRequest("Invalid move!");}

            Round round = _roundService.CreateRound(playerMove);
            return await _gameService.PlayRound(gameNumber, round);    
        }

        [HttpGet("end/{gameNumber}")]
        public async Task<ActionResult<GameStatsDTO>> EndGame(int gameNumber)
        {
            return await _gameService.EndGame(gameNumber);
        }
    }
}