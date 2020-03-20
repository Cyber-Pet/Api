using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class PetRespository : IPetRepository
    {
        private readonly CyberPetContext _context;
        private readonly INotifier _notifier;
        public PetRespository(CyberPetContext context, INotifier notifier)
        {
            _context = context;
            _notifier = notifier;
        }
        public Task<int> CreateAsync(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Pet> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetOneBy(Expression<Func<Pet, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Pet user)
        {
            throw new NotImplementedException();
        }
    }
}
