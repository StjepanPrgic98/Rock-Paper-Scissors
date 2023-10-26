using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using POS_Blagajna_Backend.Data.Repositories;
using Rock_Paper_Scissors_Backend.Entities;

namespace Rock_Paper_Scissors_Backend.Interfaces.IRepositories
{
    public interface IRoundRepository
    {
        Task<Round> CreateRound();
    }
}