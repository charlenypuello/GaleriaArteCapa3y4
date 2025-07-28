using Microsoft.AspNetCore.Mvc;
using GaleriadeArte.Application.Contracts;
using GaleriadeArte.Application.DTOs;
using GaleriaArteCapa.Infrastructure.Exceptions;

namespace GaleriaArteCapa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtworkController : ControllerBase
    {
        private readonly IArtworkService _artworkService;
        
        public ArtworkController(IArtworkService artworkService)
        {
            _artworkService = artworkService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtworkReadDto>>> GetAll()
        {
            try
            {
                var result = await _artworkService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtworkReadDto>> GetById(int id)
        {
            try
            {
                var result = await _artworkService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Artwork con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ArtworkNotFoundException)
            {
                return NotFound($"Artwork con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ArtworkReadDto>> Create([FromBody] ArtworkCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _artworkService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ArtworkValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ArtworkReadDto>> Update(int id, [FromBody] ArtworkUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _artworkService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Artwork con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ArtworkNotFoundException)
            {
                return NotFound($"Artwork con ID {id} no encontrado");
            }
            catch (ArtworkValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _artworkService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Artwork con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (ArtworkNotFoundException)
            {
                return NotFound($"Artwork con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}