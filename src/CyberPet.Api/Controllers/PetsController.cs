using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CyberPet.Api.Controllers
{
    [Route("api/[controller]")]
    public class PetsController : CoreCrudController<IPetService, PetRequest, PetResponse, Pet>
    {
        public PetsController(INotifier notifier, IMapper mapper, IPetService petService) : base(notifier, mapper, petService)
        {

        }
    }
}
