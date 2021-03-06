﻿using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.Views;

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

            CreateMap<ScheduleRequest, Schedule>();
            CreateMap<Schedule, ScheduleResponse>();

            CreateMap<BowlRequest, Bowl>();
            CreateMap<Bowl, BowlResponse>();

        }
    }
}
