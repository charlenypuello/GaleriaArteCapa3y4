using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GaleriaArteCapa.Domain.Entities
{
    public partial class Interaccione
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string? Comentario { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public int ObraId { get; set; }
    }
}