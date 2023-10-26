using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Backend.Data.Repositories
{
    public class BaseRepository
    {
        private readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;        
        }
    }
}