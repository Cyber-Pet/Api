using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        public async Task<int> CreateAsync(Pet newPet)
        {
            Pet pet = await _context.Pets.FirstOrDefaultAsync(x => x.UserId == newPet.UserId && x.PetName == newPet.PetName);
            if (pet != null)
            {
                _notifier.Add(new Notification("Já existe um pet cadastrado com este nome"));
                return -1;
            }
            await _context.Pets.AddAsync(newPet);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            Pet pet = await GetByIdAsync(id);
            if (pet == null) return -1;
            _context.Pets.Remove(pet);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            var pets = await _context.Pets.ToListAsync();
            if (!pets.Any())
            {
                _notifier.Add(new Notification("Não existe Pets cadastrados"));
                return null;
            }
            return pets;
        }

        public async Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id)
        {
            var pets = await _context.Pets
                .Where(x => x.UserId == id)
                .ToListAsync();
            if (!pets.Any())
            {
                _notifier.Add(new Notification("Não existe pets cadastrados"));
                return null;
            }
            return pets;
        }

        public async Task<Pet> GetByIdAsync(Guid id)
        {
            Pet pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet == null)
            {
                _notifier.Add(new Notification("Não existe pets cadastrados"));
                return null;
            }
            return pet;
        }

        public Task<int> UpdateAsync(Pet user)
        {
            throw new NotImplementedException();
        }
    }
}
