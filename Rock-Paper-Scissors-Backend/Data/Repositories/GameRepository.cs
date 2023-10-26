using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Interfaces.IRepositories;

namespace Rock_Paper_Scissors_Backend.Data.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(DataContext context) : base(context)
        {
        }

        public Task<int> StartNewGame()
        {
            throw new NotImplementedException();
        }
    }
}