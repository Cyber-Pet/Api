using AutoMapper;
using CyberPet.Api.Controllers.Base;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CyberPet.Api.Controllers
{
    public class UsersController : CoreCrudController<IUserService, UserRequest ,UserResponse, User>
    {
        public UsersController(INotifier notifier, IMapper mapper, IUserService userService) : base(notifier, mapper, userService) { }

    }
}