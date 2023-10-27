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

        public async Task<GameStatsDTO> StartNewGame()
        {
            Game game = new Game
            {
                Active = true,
                Rounds = new List<Round>()
            };
            
            //Save the game first to get the gameId
            game = await _gameRepository.StartNewGame(game);

            GameStatsDTO gameStatsDTO = GenerateGameStats(game);
            return gameStatsDTO;
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

        private List<GameStatsDTO> GenerateListOfGameData(List<Game> games)
        {
            List<GameStatsDTO> gameStatsDTOs = new List<GameStatsDTO>();

            foreach (var game in games)
            {
                gameStatsDTOs.Add(GenerateGameStats(game));
            }

            return gameStatsDTOs;
        }

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

            for (int i = 0; i < rounds.Count; i++)
            {
                RoundDTO roundDTO = new RoundDTO
                {
                    RoundNumber = i + 1,
                    PlayerMove = rounds[i].PlayerMove,
                    PcMove = rounds[i].PcMove,
                    Result = rounds[i].Result
                };

                roundDTOs.Add(roundDTO);
            }

            return roundDTOs;
        }


        public bool CheckIfGameExists(int id)
        {
            return _gameRepository.CheckIfGameExists(id);
        }

        public bool CheckIfGameIsActive(int id)
        {
            return _gameRepository.CheckIfGameIsActive(id);
        }
    }
}