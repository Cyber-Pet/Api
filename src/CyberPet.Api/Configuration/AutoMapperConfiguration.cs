using AutoMapper;
using CyberPet.Api.Models;
using CyberPet.Api.ViewModel;

namespace CyberPet.Api.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Pet, PetViewModel>();
        }
    }
}
