using AutoMapper;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Application.Mapping
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioReadDto>();
            
            CreateMap<UsuarioCreateDto, Usuario>();
            
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}