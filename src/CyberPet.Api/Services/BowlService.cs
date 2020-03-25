using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Base;
using CyberPet.Api.Services.Interfaces;

namespace CyberPet.Api.Services
{
    public class BowlService : CoreCrudService<Bowl,IBowlRepository>, IBowlService
    {
        public BowlService(INotifier notifier, IBowlRepository bowlRepository) : base(notifier, bowlRepository) { }
    }
}
