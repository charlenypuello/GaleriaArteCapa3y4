using AutoMapper;
using GaleriadeArte.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;

namespace GaleriadeArte.Application.Mapping
{
    public class ArtworkProfile : Profile
    {
        public ArtworkProfile()
        {
            // Entity to ReadDto
            CreateMap<Artwork, ArtworkReadDto>();
            
            // CreateDto to Entity
            CreateMap<ArtworkCreateDto, Artwork>();
            
            // UpdateDto to Entity
            CreateMap<ArtworkUpdateDto, Artwork>();
        }
    }
}