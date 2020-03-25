using CyberPet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories.Interfaces
{
    interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id);
        Task<Pet> GetByIdAsync(Guid id);
        Task<int> CreateAsync(Pet newPet);
        Task<int> UpdateAsync(Pet updatedPet);
        Task<int> DeleteAsync(Guid id);
    }
}
