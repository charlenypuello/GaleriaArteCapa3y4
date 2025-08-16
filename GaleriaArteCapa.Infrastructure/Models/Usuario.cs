using System;
using System.Collections.Generic;

namespace GaleriaArteCapa.Infrastructure.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Interaccione> Interacciones { get; set; } = new List<Interaccione>();

    public virtual ICollection<Obra> Obras { get; set; } = new List<Obra>();
}
