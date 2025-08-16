using GaleriaArteCapa.Application.DTOs;

namespace GaleriaArteCapa.Application.Contracts
{
    public interface IInteraccioneService : IBaseService<InteraccioneReadDto, InteraccioneCreateDto, InteraccioneUpdateDto>
    {

        Task<InteraccioneReadDto> GetWithUser(int  id);
    }
}