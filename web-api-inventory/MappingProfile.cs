using api_inventory.Models;
using AutoMapper;
using web_api_inventory.Models;

public class MappingProfile : Profile {
    public MappingProfile () {
        CreateMap<AppUser, RegistrationViewModel> ();
    }
}