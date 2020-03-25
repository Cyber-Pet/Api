using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;

namespace CyberPet.Api.Controllers
{
    public class ScheduleController : CoreCrudController<IScheduleService , ScheduleRequest, ScheduleResponse , Schedule>
    {
        public ScheduleController(INotifier notifier, IMapper mapper, IScheduleService scheduleService) : base(notifier, mapper, scheduleService) { }
    }
}
