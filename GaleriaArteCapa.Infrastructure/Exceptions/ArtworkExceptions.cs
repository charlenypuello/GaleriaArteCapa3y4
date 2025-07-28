using System;

namespace GaleriaArteCapa.Infrastructure.Exceptions
{
    public class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException() : base($"Artwork no encontrado")
        {
        }
        
        public ArtworkNotFoundException(int id) : base($"Artwork con ID {id} no encontrado")
        {
        }
        
        public ArtworkNotFoundException(string message) : base(message)
        {
        }
        
        public ArtworkNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    
    public class ArtworkValidationException : Exception
    {
        public ArtworkValidationException(string message) : base(message)
        {
        }
        
        public ArtworkValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}