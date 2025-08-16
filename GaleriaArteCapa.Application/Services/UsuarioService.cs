using AutoMapper;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.Core;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Interfaces;

namespace GaleriaArteCapa.Application.Services
{
    public class UsuarioService : BaseService<Usuario, UsuarioReadDto, UsuarioCreateDto, UsuarioUpdateDto>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _usuarioRepository = repository;
        }

        public async Task<UsuarioReadDto> Login(string username, string password)
        {
            var usuario = await _usuarioRepository.Login(username, password);
            if (usuario == null)
            {
                throw new Exception("Usuario o contrasena invalida");
            }
            var usuarioRead = _mapper.Map<UsuarioReadDto>(usuario);
            return usuarioRead;
        }

        public async Task<UsuarioCreateDto> RegistraUsuario(UsuarioCreateDto usuarioRead)
        {
            var existUsuario = await _usuarioRepository.isExist(usuarioRead.Usuario1, usuarioRead.Contrasena);
            if (existUsuario)
            {
                throw new Exception("El usuario ya existe");
            }
            var usuario = _mapper.Map<Usuario>(usuarioRead);
            await _usuarioRepository.AddAsync(usuario);

            if (usuario == null)
            {
                throw new Exception("Ha ocurrido un error al guardar el usuario");
            }
            return _mapper.Map<UsuarioCreateDto>(usuarioRead);
        }
    }
}