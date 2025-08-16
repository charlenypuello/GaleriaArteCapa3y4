using AutoMapper;
        using GaleriaArteCapa.Application.DTOs;
        using GaleriaArteCapa.Domain.Entities;


namespace GaleriaArteCapa.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Interaccione, InteraccioneReadDto>();
            CreateMap<Obra, ObraReadDto>();
            CreateMap<Usuario, UsuarioReadDto>();
            CreateMap<InteraccioneCreateDto, Interaccione>();
            CreateMap<ObraCreateDto, Obra>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<InteraccioneUpdateDto, Interaccione>();
            CreateMap<ObraUpdateDto, Obra>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}