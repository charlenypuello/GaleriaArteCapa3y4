using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Application.DTOs
{
    public class UsuarioCreateDto
    {

        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}