using AutoMapper;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriadeArte.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Artwork mappings
            // ObrasDeArte mappings
            CreateMap<Artwork, DTOs.ArtworkReadDto>();
            CreateMap<ObrasDeArte, DTOs.ObrasDeArteReadDto>();
            CreateMap<DTOs.ArtworkCreateDto, Artwork>();
            CreateMap<DTOs.ObrasDeArteCreateDto, ObrasDeArte>();
            CreateMap<DTOs.ArtworkUpdateDto, Artwork>();
            CreateMap<DTOs.ObrasDeArteUpdateDto, ObrasDeArte>();
        }
    }
}