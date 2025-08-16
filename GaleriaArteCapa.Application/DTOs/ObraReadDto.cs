using System;

namespace GaleriaArteCapa.Application.DTOs
{
    public class ObraReadDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string Categoria { get; set; }
        public string? UrlImagen { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public UsuarioReadDto Usuario { get; set; } = new UsuarioReadDto();

        public List<InteraccioneReadDto> Interacciones { get; set; } = new List<InteraccioneReadDto>();
    }
}