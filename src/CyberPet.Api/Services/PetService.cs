using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Base;
using CyberPet.Api.Services.Interfaces;

namespace CyberPet.Api.Services
{
    public class PetService : CoreCrudService<Pet, IPetRepository>, IPetService
    {
        public PetService(INotifier notifier, IPetRepository petRepository) : base(notifier, petRepository) { }
    }
}
