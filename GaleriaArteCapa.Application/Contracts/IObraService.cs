using GaleriaArteCapa.Application.DTOs;

namespace GaleriaArteCapa.Application.Contracts
{
    public interface IObraService : IBaseService<ObraReadDto, ObraCreateDto, ObraUpdateDto>
    {
        Task<List<ObraReadDto>> GetAllWithUserAndInteraccionesAsync();
    }
}