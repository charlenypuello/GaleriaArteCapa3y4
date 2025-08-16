using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Infrastructure.Interfaces
{
    public interface IInteraccioneRepository : IBaseRepository<Interaccione>
    {
        Task<Interaccione?> GetWithUser(int ID);
    }
}