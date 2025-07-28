using System;

namespace GaleriadeArte.Application.DTOs
{
    public class ArtworkReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string ImageUrl { get; set; }
    }
}