using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Domain.Entities
{
    public partial class Obra
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string? Descripcion { get; set; }
        public string Categoria { get; set; }
        public string? UrlImagen { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();
    }
}