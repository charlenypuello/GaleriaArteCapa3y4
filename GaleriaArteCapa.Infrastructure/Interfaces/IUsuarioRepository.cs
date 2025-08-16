using GaleriaArteCapa.Domain.Entities;

namespace GaleriaArteCapa.Infrastructure.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<bool> isExist(string usuario, string contra);

        Task<Usuario?> Login(string username, string password);
       


    }
}