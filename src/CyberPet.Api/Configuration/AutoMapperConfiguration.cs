﻿using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.ViewModel;

namespace CyberPet.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<PetRequest, Pet>();
            CreateMap<Pet, PetResponse>();

            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();

        }
    }
}
