using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;

namespace GaleriaArteCapa.Infrastructure.Repositories
{
    public class ArtworkRepository : BaseRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(GADbContext context) : base(context)
        {
        }
        
        // Implementar métodos específicos adicionales aquí si los necesitas
    }
}