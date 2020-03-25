using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Base;
using CyberPet.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class ScheduleService : CoreCrudService<Schedule, IScheduleRepository> , IScheduleService
    {
        public ScheduleService(INotifier notifier, IScheduleRepository scheduleRepository) : base(notifier, scheduleRepository) { }
    }
}
