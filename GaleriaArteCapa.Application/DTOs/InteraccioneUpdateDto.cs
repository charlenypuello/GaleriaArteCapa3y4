using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Application.DTOs
{
    public class InteraccioneUpdateDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string? Comentario { get; set; }
        public int UsuarioId { get; set; }
        public int ObraId { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}