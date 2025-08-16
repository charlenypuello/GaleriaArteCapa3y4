using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Context;
using GaleriaArteCapa.Infrastructure.Core;
using GaleriaArteCapa.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GaleriaArteCapa.Infrastructure.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(GADbContext context) : base(context)
        {
        }

        public async Task<bool> isExist(string usuario, string contra)
        {
            return await _context.Usuarios
                .AnyAsync(u => u.Usuario1 == usuario && u.Contrasena == contra);
        }

        public async Task<Usuario?> Login(string username, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario1 == username && u.Contrasena == password);
        }
    }
}