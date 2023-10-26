using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Rock_Paper_Scissors_Backend.DTOs;
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

        public async Task<IEnumerable<GameStatsDTO>> GetListOfGames()
        {
            IEnumerable<Game> games = await _gameRepository.GetListOfGames();
            return GenerateListOfGameData(games.ToList());
        }

        public async Task<GameStatsDTO> GetGameById(int id)
        {
            GameStatsDTO gameStatsDTO = GenerateGameStats(await _gameRepository.GetGameById(id));
            return gameStatsDTO;
        }

        public async Task<int> StartNewGame()
        {
            Game game = new Game
            {
                Active = true
            };

            return await _gameRepository.StartNewGame(game);
        }

        public async Task<GameStatsDTO> PlayRound(int id, Round round)
        {
            Game game = await _gameRepository.GetGameById(id);
            game.Rounds.Add(round);

            GameStatsDTO gameStatsDTO = GenerateGameStats(await _gameRepository.SaveGame(game));

            return gameStatsDTO;
        }

        public async Task<GameStatsDTO> EndGame(int id)
        {
            Game game = await _gameRepository.GetGameById(id);
            game.Active = false;
            game.EndTime = DateTime.UtcNow;

            GameStatsDTO gameStatsDTO = GenerateGameStats(await _gameRepository.SaveGame(game));

            return gameStatsDTO;
        }

        // Generates a number between 100000 and 999999 that will be used as unique game number.

        private GameStatsDTO GenerateGameStats(Game game)
        {
            GameStatsDTO gameStatsDTO = new GameStatsDTO
            {
                GameId = game.Id,
                Active = game.Active,
                StartTime = game.StartTime,
                EndTime = game.EndTime,
                NumberOfRounds = game.Rounds.Count,
                Wins = game.Rounds.Count(x => x.Result == "Victory"),
                Losses = game.Rounds.Count(x => x.Result == "Loss"),
                Draws = game.Rounds.Count(x => x.Result == "Draw"),
                Rounds = GenerateRoundsData(game.Rounds.ToList())
            };

            return gameStatsDTO;
        }

        private List<RoundDTO> GenerateRoundsData(List<Round> rounds)
        {
            List<RoundDTO> roundDTOs = new List<RoundDTO>();

            foreach (var round in rounds)
            {
                RoundDTO roundDTO = new RoundDTO
                {
                    PlayerMove = round.PlayerMove,
                    PcMove = round.PcMove,
                    Result = round.Result
                };
                
                roundDTOs.Add(roundDTO);
            }

            return roundDTOs;
        }

        private List<GameStatsDTO> GenerateListOfGameData(List<Game> games)
        {
            List<GameStatsDTO> gameStatsDTOs = new List<GameStatsDTO>();

            foreach (var game in games)
            {
                gameStatsDTOs.Add(GenerateGameStats(game));
            }

            return gameStatsDTOs;
        }

        public bool CheckIfGameExists(int id)
        {
            return _gameRepository.CheckIfGameExists(id);
        }
    }
}