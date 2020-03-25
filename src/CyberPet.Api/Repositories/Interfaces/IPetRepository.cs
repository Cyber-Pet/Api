using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    public interface IPetRepository : ICoreRepository<Pet>
    {
        Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id);
        Task<Pet> GetOneByIdAsync(Guid id);

    }
}
