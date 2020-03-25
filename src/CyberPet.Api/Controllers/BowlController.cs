using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;

namespace CyberPet.Api.Controllers
{
    public class BowlController : CoreCrudController<IBowlService, BowlRequest, BowlResponse, Bowl>
    {
        public BowlController(INotifier notifier, IMapper mapper, IBowlService bowlService) : base(notifier, mapper, bowlService) { }

    }
}
