using System;
using System.ComponentModel.DataAnnotations;

namespace GaleriadeArte.Application.DTOs
{
    public class ArtworkUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}