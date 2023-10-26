using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rock_Paper_Scissors_Backend.Data;

namespace POS_Blagajna_Backend.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }
    }
}