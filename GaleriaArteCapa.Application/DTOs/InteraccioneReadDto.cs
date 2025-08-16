using System;

namespace GaleriaArteCapa.Application.DTOs
{
    public class InteraccioneReadDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string? Comentario { get; set; }
        public int UsuarioId { get; set; }
        public int ObraId { get; set; }
        public UsuarioReadDto Usuario { get; set; } = new UsuarioReadDto();
        public DateTime? FechaRegistro { get; set; }
    }
}