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
    public class ArtworkService : IArtworkService
    {
        private readonly IArtworkRepository _repository;
        private readonly IMapper _mapper;
        
        public ArtworkService(IArtworkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ArtworkReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ArtworkReadDto>>(entities);
        }
        
        public async Task<ArtworkReadDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity != null ? _mapper.Map<ArtworkReadDto>(entity) : null;
        }
        
        public async Task<ArtworkReadDto> CreateAsync(ArtworkCreateDto createDto)
        {
            var entity = _mapper.Map<Artwork>(createDto);
            var createdEntity = await _repository.AddAsync(entity);
            return _mapper.Map<ArtworkReadDto>(createdEntity);
        }
        
        public async Task<ArtworkReadDto> UpdateAsync(int id, ArtworkUpdateDto updateDto)
        {
            var existingEntity = await _repository.GetByIdAsync(id);
            if (existingEntity == null) return null;
            
            _mapper.Map(updateDto, existingEntity);
            var updatedEntity = await _repository.UpdateAsync(existingEntity);
            return _mapper.Map<ArtworkReadDto>(updatedEntity);
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}