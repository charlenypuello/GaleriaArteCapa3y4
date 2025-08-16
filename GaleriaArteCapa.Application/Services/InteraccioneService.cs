using AutoMapper;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.Core;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Interfaces;

namespace GaleriaArteCapa.Application.Services
{
    public class InteraccioneService : BaseService<Interaccione, InteraccioneReadDto, InteraccioneCreateDto, InteraccioneUpdateDto>, IInteraccioneService
    {
        private readonly IInteraccioneRepository _interaccioneRepository;
        
        public InteraccioneService(IInteraccioneRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
            _interaccioneRepository = repository;
        }

        public async Task<InteraccioneReadDto> GetWithUser(int id)
        {
            var withuser = await _interaccioneRepository.GetWithUser(id);
            return _mapper.Map<InteraccioneReadDto>(withuser);
        }
    }
}