using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;
using CyberPet.Api.Workers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{

    public class PetsController : CoreCrudController<IPetService, PetRequest, PetResponse, Pet>
    {
        private readonly IMapper mapper;
        private readonly IPetService petService;
        private readonly INotifier notifier;

        public PetsController(INotifier notifier, IMapper mapper, IPetService petService) : base(notifier, mapper, petService)
        {
            this.mapper = mapper;
            this.petService = petService;
            this.notifier = notifier;
        }
        
        [HttpPost("{id:guid}/feed")]
        public async Task<ActionResult> FeedPet(Guid id)
        {
            using (CyberPetContext context = new CyberPetContext())
            {
                string bowlToken = context.Pets
                    .Include(x => x.Bowl)
                    .FirstOrDefault()?
                    .Bowl?.Token;

                if (string.IsNullOrWhiteSpace(bowlToken))
                {
                    notifier.Add("Não existe pode cadastrado para este Pet");
                    return CustomBadRequest();
                }
                await ScheduleWorker.ConnectMqttServer();
                await ScheduleWorker.RunBowl(bowlToken);
                return CustomResponse("Pet Alimentado!", null);
            }

        }


        [HttpGet("user/{id:guid}")]
        public virtual async Task<ActionResult<PetResponse>> GetAllByUserIdAsync(Guid id)
        {
            if (!ModelState.IsValid) return CustomBadRequest(ModelState);
            var resultado = await this.petService.GetAllByUserIdAsync(id);
            var responseList = this.mapper.Map<List<PetResponse>>(resultado);

            foreach (var response in responseList)
            {
                response.BowlId = resultado.FirstOrDefault(x => x.Bowl?.PetId == response.Id)?.Bowl.Id ?? null;
            }

            return CustomResponse("Registros encontrados!", responseList);
        }
    }
}
