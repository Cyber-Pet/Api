using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Base;
using CyberPet.Api.Repositories.Interfaces;

namespace CyberPet.Api.Repositories
{
    public class BowlRepository : CoreRepository<Bowl>, IBowlRepository
    {
        public BowlRepository(CyberPetContext context, INotifier notifier) : base(context, notifier) { }
    }
}
