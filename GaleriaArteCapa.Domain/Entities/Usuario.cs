using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Domain.Entities
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();
        public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
    }
}