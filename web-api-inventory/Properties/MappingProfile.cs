using api_inventory.Model;
using AutoMapper;
using web_api_inventory.Model.View;

public class MappingProfile : Profile {
    public MappingProfile () {
        CreateMap<RegistrationViewModel, AppUser> ();
    }
}
