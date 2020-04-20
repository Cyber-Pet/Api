using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    
    public class PetsController : CoreCrudController<IPetService, PetRequest, PetResponse, Pet>
    {
        private readonly IMapper mapper;
        private readonly IPetService petService;

        public PetsController(INotifier notifier, IMapper mapper, IPetService petService) : base(notifier, mapper, petService)
        {
            this.mapper = mapper;
            this.petService = petService;
        }

        [HttpGet("user/{id:guid}")]
        public virtual async Task<ActionResult<PetResponse>> GetAllByUserIdAsync(Guid id)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var resultado = await this.petService.GetAllByUserIdAsync(id);
            return CustomResponse("Registros encontrados!", this.mapper.Map<List<PetResponse>>(resultado));
        }
    }
}
