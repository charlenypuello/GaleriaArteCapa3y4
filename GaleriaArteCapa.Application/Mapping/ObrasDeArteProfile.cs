using AutoMapper;
using GaleriadeArte.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriadeArte.Application.Mapping
{
    public class ObrasDeArteProfile : Profile
    {
        public ObrasDeArteProfile()
        {
            // Entity to ReadDto
            CreateMap<ObrasDeArte, ObrasDeArteReadDto>();
            
            // CreateDto to Entity
            CreateMap<ObrasDeArteCreateDto, ObrasDeArte>();
            
            // UpdateDto to Entity
            CreateMap<ObrasDeArteUpdateDto, ObrasDeArte>();
        }
    }
}