using System;

namespace GaleriadeArte.Application.DTOs
{
    public class ObrasDeArteReadDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string ImagenUrl { get; set; }
    }
}