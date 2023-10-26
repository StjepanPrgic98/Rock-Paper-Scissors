using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Data.Repositories;
using Rock_Paper_Scissors_Backend.Entities;
using Rock_Paper_Scissors_Backend.Interfaces.IRepositories;

namespace Rock_Paper_Scissors_Backend.Data.Repositories
{
    public class RoundRepository : BaseRepository, IRoundRepository
    {
        public RoundRepository(DataContext context) : base(context)
        {
        }

        public Task<Round> CreateRound()
        {
            throw new NotImplementedException();
        }
    }
}