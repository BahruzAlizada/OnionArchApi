
using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Identity;

namespace OnionArch.Application.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Product,ProductAddDto>().ReverseMap();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();
            CreateMap<Product,ProductDto>().ReverseMap();

            CreateMap<AppUser,UserDto>().ReverseMap();

            CreateMap<AppRole,RoleAddDto>().ReverseMap();
            CreateMap<AppRole,RoleUpdateDto>().ReverseMap();
            CreateMap<AppRole, RoleDto>().ReverseMap(); 
        }
    }
}
