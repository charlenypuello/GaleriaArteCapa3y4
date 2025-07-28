using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriadeArte.Application.DTOs
{
    public class ArtworkCreateDto
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}