using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Application.DTOs
{
    public class ObraUpdateDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string Categoria { get; set; }
        public string? UrlImagen { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}