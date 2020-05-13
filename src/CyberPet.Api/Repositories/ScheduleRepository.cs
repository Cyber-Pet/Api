using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Base;
using CyberPet.Api.Repositories.Interfaces;

namespace CyberPet.Api.Repositories
{
    public class ScheduleRepository : CoreRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(CyberPetContext context, INotifier notifier) : base(context, notifier)
        { }

    }
}
