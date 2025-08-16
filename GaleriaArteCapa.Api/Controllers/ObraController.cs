using Microsoft.AspNetCore.Mvc;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Infrastructure.Exceptions;

namespace GaleriaArteCapa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObraController : ControllerBase
    {
        private readonly IObraService _obraService;
        
        public ObraController(IObraService obraService)
        {
            _obraService = obraService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraReadDto>>> GetAll()
        {
            try
            {
                var result = await _obraService.GetAllWithUserAndInteraccionesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ObraReadDto>> GetById(int id)
        {
            try
            {
                var result = await _obraService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Obra con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ObraNotFoundException)
            {
                return NotFound($"Obra con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ObraReadDto>> Create([FromBody] ObraCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _obraService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ObraValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ObraReadDto>> Update(int id, [FromBody] ObraUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _obraService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Obra con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ObraNotFoundException)
            {
                return NotFound($"Obra con ID {id} no encontrado");
            }
            catch (ObraValidationException ex)
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
                var result = await _obraService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Obra con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (ObraNotFoundException)
            {
                return NotFound($"Obra con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}