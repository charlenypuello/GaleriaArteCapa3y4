using AutoMapper;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Application.Mapping
{
    public class InteraccioneProfile : Profile
    {
        public InteraccioneProfile()
        {
            CreateMap<Interaccione, InteraccioneReadDto>();
            
            CreateMap<InteraccioneCreateDto, Interaccione>();
            
            CreateMap<InteraccioneUpdateDto, Interaccione>();
        }
    }
}