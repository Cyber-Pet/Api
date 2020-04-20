using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services.Interfaces
{
    public interface IPetService : ICoreCrudService<Pet>
    {
        public Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id);
    }
}
