﻿using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.ViewModel;

namespace CyberPet.Api
{
    public class CyberPetProfile : Profile
    {
        public CyberPetProfile()
        {
            CreateMap<User, Token>();
            CreateMap<UserResgister, User>();
        }
    }
}