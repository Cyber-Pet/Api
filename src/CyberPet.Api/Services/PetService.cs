﻿using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services.Base;
using CyberPet.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Services
{
    public class PetService : CoreCrudService<Pet, IPetRepository>, IPetService
    {
        public PetService(INotifier notifier, IPetRepository petRepository) : base(notifier, petRepository) { }

        public Task<IEnumerable<Pet>> GetAllByUserIdAsync(Guid id)
        {
            return _repository.GetAllByUserIdAsync(id);
        }
    }
}
