using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;
using Microsoft.AspNetCore.Mvc;

namespace CyberPet.Api.Controllers
{
    public class ScheduleController : CoreCrudController<IScheduleService , ScheduleRequest, ScheduleResponse , Schedule>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleService _scheduleService;
        public ScheduleController(INotifier notifier, IMapper mapper, IScheduleService scheduleService) : base(notifier,
            mapper, scheduleService)
        {
            _scheduleService = scheduleService;
            _mapper = mapper;
        }


        [HttpGet("pet/{id:guid}")]
        public async Task<ActionResult<List<ScheduleResponse>>> GetByPetId(Guid id)
        {
            return _mapper.Map<List<ScheduleResponse>>(await _scheduleService.GetByCondition(x => x.PetId.Equals(id)));
        }
    }
}
