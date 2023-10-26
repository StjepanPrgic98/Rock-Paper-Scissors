using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Round> Rounds { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}