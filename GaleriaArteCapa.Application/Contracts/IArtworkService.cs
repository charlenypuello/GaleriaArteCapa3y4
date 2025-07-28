using GaleriadeArte.Application.DTOs;

namespace GaleriadeArte.Application.Contracts
{
    public interface IArtworkService : IBaseService<ArtworkReadDto, ArtworkCreateDto, ArtworkUpdateDto>
    {
        // Métodos específicos adicionales para Artwork si los necesitas
    }
}