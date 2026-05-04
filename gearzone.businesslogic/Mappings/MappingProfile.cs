using AutoMapper;
using gearzone.domains.Entities;
using gearzone.domains.DTOs;

namespace gearzone.businesslogic.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}