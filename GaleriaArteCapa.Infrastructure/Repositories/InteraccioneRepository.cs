using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GaleriaArteCapa.Infrastructure.Repositories
{
    public class InteraccioneRepository : BaseRepository<Interaccione>, IInteraccioneRepository
    {
        public InteraccioneRepository(GADbContext context) : base(context)
        {
        }

        public async Task<Interaccione?> GetWithUser(int ID)
        {
            return await _context.Interacciones.Include(u => u.Usuario).FirstOrDefaultAsync(x => x.Id == ID);
        }
    }
}