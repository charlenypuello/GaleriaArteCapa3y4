using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GaleriadeArte.Application.Contracts;
using GaleriadeArte.Application.DTOs;
using GaleriaArteCapa.Domain.Entities;
using GaleriaArteCapa.Infrastructure.Interfaces;

namespace GaleriaArteCapa.Domain.Services
{
    public class ObrasDeArteService : IObrasDeArteService
    {
        private readonly IObrasDeArteRepository _repository;
        private readonly IMapper _mapper;
        
        public ObrasDeArteService(IObrasDeArteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ObrasDeArteReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ObrasDeArteReadDto>>(entities);
        }
        
        public async Task<ObrasDeArteReadDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity != null ? _mapper.Map<ObrasDeArteReadDto>(entity) : null;
        }
        
        public async Task<ObrasDeArteReadDto> CreateAsync(ObrasDeArteCreateDto createDto)
        {
            var entity = _mapper.Map<ObrasDeArte>(createDto);
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<ObrasDeArteReadDto>(createdEntity);
        }
        
        public async Task<ObrasDeArteReadDto> UpdateAsync(int id, ObrasDeArteUpdateDto updateDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) return null;
            
            _mapper.Map(updateDto, existingEntity);
            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            return _mapper.Map<ObrasDeArteReadDto>(updatedEntity);
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}