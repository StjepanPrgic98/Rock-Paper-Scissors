using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Data.Repositories;
using Rock_Paper_Scissors_Backend.DTOs;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IRepositories;

namespace Rock_Paper_Scissors_Backend.Data.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Game>> GetListOfGames()
        {
            return await _context.Games
                .Include(x => x.Rounds)
                .ToListAsync();
        }

        public async Task<Game> StartNewGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> SaveGame(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> GetGameById(int id)
        {
            return await _context.Games
                .Include(x => x.Rounds)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool CheckIfGameExists(int id)
        {
            return _context.Games.Any(x => x.Id == id);
        }

        public bool CheckIfGameIsActive(int id)
        {
            return _context.Games.Any(x => x.Id == id && x.Active);
        }
    }
}