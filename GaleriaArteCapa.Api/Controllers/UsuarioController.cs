using Microsoft.AspNetCore.Mvc;
using GaleriaArteCapa.Application.Contracts;
using GaleriaArteCapa.Application.DTOs;
using GaleriaArteCapa.Infrastructure.Exceptions;

namespace GaleriaArteCapa.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioReadDto>>> GetAll()
        {
            try
            {
                var result = await _usuarioService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> GetById(int id)
        {
            try
            {
                var result = await _usuarioService.GetByIdAsync(id);
                if (result == null)
                    return NotFound($"Usuario con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (UsuarioNotFoundException)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<UsuarioReadDto>> Create([FromBody] UsuarioCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _usuarioService.RegistraUsuario(createDto);
                return CreatedAtAction(nameof(GetById), new { id = result.Usuario1 }, result);
            }
            catch (UsuarioValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UsuarioReadDto>> Login([FromBody] LoginDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _usuarioService.Login(createDto.Usuario, createDto.Contrasena);
                return CreatedAtAction(nameof(GetById), new { id = result.Usuario1 }, result);
            }
            catch (UsuarioValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioReadDto>> Update(int id, [FromBody] UsuarioUpdateDto updateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                    
                var result = await _usuarioService.UpdateAsync(id, updateDto);
                if (result == null)
                    return NotFound($"Usuario con ID {id} no encontrado");
                    
                return Ok(result);
            }
            catch (UsuarioNotFoundException)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            catch (UsuarioValidationException ex)
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
                var result = await _usuarioService.DeleteAsync(id);
                if (!result)
                    return NotFound($"Usuario con ID {id} no encontrado");
                    
                return NoContent();
            }
            catch (UsuarioNotFoundException)
            {
                return NotFound($"Usuario con ID {id} no encontrado");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }
    }
}