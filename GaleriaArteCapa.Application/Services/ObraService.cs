using AutoMapper;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.Core;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Interfaces;

namespace GaleriaArteCapa.Application.Services
{
    public class ObraService : BaseService<Obra, ObraReadDto, ObraCreateDto, ObraUpdateDto>, IObraService
    {
        private readonly IObraRepository _obraRepository;
        
        public ObraService(IObraRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _obraRepository = repository;
        }

        public async Task<List<ObraReadDto>> GetAllWithUserAndInteraccionesAsync()
        {
            var obras = await _obraRepository.GetAllWithUserAndInteraccionesAsync();

            return _mapper.Map<List<ObraReadDto>>(obras);

        }
    }
}