using Microsoft.AspNetCore.Mvc;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Infrastructure.Exceptions;

namespace GaleriaArteCapa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InteraccioneController : ControllerBase
    {
        private readonly IInteraccioneService _interaccioneService;
        
        public InteraccioneController(IInteraccioneService interaccioneService)
        {
            _interaccioneService = interaccioneService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InteraccioneReadDto>>> GetAll()
        {
            try
            {
                var result = await _interaccioneService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<InteraccioneReadDto>> GetById(int id)
        {
            try
            {
                var result = await _interaccioneService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Interaccione con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (InteraccioneNotFoundException)
            {
                return NotFound($"Interaccione con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<InteraccioneReadDto>> Create([FromBody] InteraccioneCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _interaccioneService.CreateAsync(createDto);

                var interacionWithUser = await _interaccioneService.GetWithUser(result.Id);
                return CreatedAtAction(nameof(GetById), new { id = interacionWithUser.Id }, interacionWithUser);
            }
            catch (InteraccioneValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<InteraccioneReadDto>> Update(int id, [FromBody] InteraccioneUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _interaccioneService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Interaccione con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (InteraccioneNotFoundException)
            {
                return NotFound($"Interaccione con ID {id} no encontrado");
            }
            catch (InteraccioneValidationException ex)
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
                var result = await _interaccioneService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Interaccione con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (InteraccioneNotFoundException)
            {
                return NotFound($"Interaccione con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}