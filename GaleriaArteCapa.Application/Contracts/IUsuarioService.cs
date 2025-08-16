using GaleriaArteCapa.Application.DTOs;

namespace GaleriaArteCapa.Application.Contracts
{
    public interface IUsuarioService : IBaseService<UsuarioReadDto, UsuarioCreateDto, UsuarioUpdateDto>
    {
        Task<UsuarioCreateDto> RegistraUsuario(UsuarioCreateDto usuarioRead);
        Task<UsuarioReadDto> Login(string username, string password);
    }
}