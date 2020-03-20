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
        Task<Pet> GetByIdAsync(Guid id);
        Task<User> GetOneBy(Expression<Func<Pet, bool>> expression);
        Task<int> CreateAsync(Pet pet);
        Task<int> UpdateAsync(Pet pet);
        Task<int> DeleteAsync(Guid id);
    }
}
