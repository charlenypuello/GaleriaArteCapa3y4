using Microsoft.AspNetCore.Mvc;
using GaleriadeArte.Application.Contracts;
using GaleriadeArte.Application.DTOs;
using GaleriaArteCapa.Infrastructure.Exceptions;

namespace GaleriaArteCapa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObrasDeArteController : ControllerBase
    {
        private readonly IObrasDeArteService _obrasdearteService;
        
        public ObrasDeArteController(IObrasDeArteService obrasdearteService)
        {
            _obrasdearteService = obrasdearteService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObrasDeArteReadDto>>> GetAll()
        {
            try
            {
                var result = await _obrasdearteService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ObrasDeArteReadDto>> GetById(int id)
        {
            try
            {
                var result = await _obrasdearteService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"ObrasDeArte con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ObrasDeArteNotFoundException)
            {
                return NotFound($"ObrasDeArte con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<ObrasDeArteReadDto>> Create([FromBody] ObrasDeArteCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _obrasdearteService.CreateAsync(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (ObrasDeArteValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ObrasDeArteReadDto>> Update(int id, [FromBody] ObrasDeArteUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _obrasdearteService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"ObrasDeArte con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (ObrasDeArteNotFoundException)
            {
                return NotFound($"ObrasDeArte con ID {id} no encontrado");
            }
            catch (ObrasDeArteValidationException ex)
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
                var result = await _obrasdearteService.DeleteAsync(id);
                if (!result)
                    return NotFound($"ObrasDeArte con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (ObrasDeArteNotFoundException)
            {
                return NotFound($"ObrasDeArte con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}