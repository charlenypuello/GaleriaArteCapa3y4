using System;
using System.Collections.Generic;

namespace GaleriaArteCapa.Infrastructure.Models;

public partial class ObrasDeArte
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string ImagenUrl { get; set; } = null!;
}
