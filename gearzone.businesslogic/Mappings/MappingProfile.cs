using AutoMapper;
using gearzone.domains.DTOs;
using gearzone.domains.Entities;

namespace gearzone.businesslogic.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
