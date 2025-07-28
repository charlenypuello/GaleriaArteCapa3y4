using System;
using System.Collections.Generic;

namespace GaleriaArteCapa.Infrastructure.Models;

public partial class Artwork
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Artist { get; set; } = null!;

    public int Year { get; set; }

    public string ImageUrl { get; set; } = null!;
}
