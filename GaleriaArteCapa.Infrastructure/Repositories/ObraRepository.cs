using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GaleriaArteCapa.Infrastructure.Repositories
{


    public class ObraRepository : BaseRepository<Obra>, IObraRepository
    {

        public ObraRepository(GADbContext context) : base(context)
        {
        }

        public async Task<List<Obra>> GetAllWithUserAndInteraccionesAsync()
        {
            return await _context.Obras
                .Include(o => o.Usuario) // trae el usuario
                .Include(o => o.Interacciones) // trae las interacciones
                .ThenInclude(o => o.Usuario)
                .ToListAsync();
        }
    }
}