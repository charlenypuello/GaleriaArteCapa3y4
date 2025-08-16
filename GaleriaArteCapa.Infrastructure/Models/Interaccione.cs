using System;
using System.Collections.Generic;

namespace GaleriaArteCapa.Infrastructure.Models;

public partial class Interaccione
{
    public int Id { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Comentario { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public int ObraId { get; set; }
    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>(); 
}
