using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Infrastructure.Interfaces
{
    public interface IObraRepository : IBaseRepository<Obra>
    {
        Task<List<Obra>> GetAllWithUserAndInteraccionesAsync();
    }
}