
using AutoMapper;
using OnionArch.Application.DTOs;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Mappers.AutoMapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Product,ProductAddDto>().ReverseMap();
            CreateMap<Product,ProductUpdateDto>().ReverseMap();
        }
    }
}
