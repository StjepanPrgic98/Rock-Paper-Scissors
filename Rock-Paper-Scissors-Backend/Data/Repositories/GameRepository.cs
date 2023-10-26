using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POS_Blagajna_Backend.Data.Repositories;
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
            return await _context.Games.ToListAsync();
        }

        public async Task<int> StartNewGame(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.GameNumber;
        }

        public async Task<Game> SaveRoundPlayed(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }


        public async Task<Game> GetGameByNumber(int gameNumber)
        {
            return await _context.Games
                .Include(x => x.Rounds)
                .FirstOrDefaultAsync(x => x.GameNumber == gameNumber);
        }

        
    }
}