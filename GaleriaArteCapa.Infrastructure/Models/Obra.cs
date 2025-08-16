using System;
using System.Collections.Generic;

namespace GaleriaArteCapa.Infrastructure.Models;

public partial class Obra
{
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Categoria { get; set; } = null!;

    public string? UrlImagen { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
}
