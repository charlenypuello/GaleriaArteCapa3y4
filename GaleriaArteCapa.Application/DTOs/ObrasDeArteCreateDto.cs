using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriadeArte.Application.DTOs
{
    public class ObrasDeArteCreateDto
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ImagenUrl { get; set; }
    }
}