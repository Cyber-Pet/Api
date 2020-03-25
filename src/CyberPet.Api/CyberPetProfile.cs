using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.Views;

namespace CyberPet.Api
{
    public class CyberPetProfile : Profile
    {
        public CyberPetProfile()
        {
            CreateMap<User, LoginResponse>();
            CreateMap<UserRequest, User>();
        }
    }
}
