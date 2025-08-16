using AutoMapper;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Application.Mapping
{
    public class ObraProfile : Profile
    {
        public ObraProfile()
        {
            CreateMap<Obra, ObraReadDto>();
            
            CreateMap<ObraCreateDto, Obra>();
            
            CreateMap<ObraUpdateDto, Obra>();
        }
    }
}