using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Base;
using CyberPet.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Repositories
{
    public class PetRespository : CoreRepository<Pet>, IPetRepository
    {

        public PetRespository(CyberPetContext context, INotifier notifier) : base(context, notifier)
        {
        }

        public async Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id)
        {
            var pets = await _context.Pets
                .Where(x => x.UserId == id)
                .ToListAsync();
            if (pets.Any())
            {
                return pets;
            }
            _notifier.Add(new Notification("Não existe pets cadastrados"));
            return null;
        }

        public async Task<Pet> GetOneByIdAsync(Guid id)
        {
            Pet pet = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (pet != null)
            {
                return pet;
            }
            _notifier.Add(new Notification("Não existe pets cadastrados"));
            return null;
        }
    }
}
